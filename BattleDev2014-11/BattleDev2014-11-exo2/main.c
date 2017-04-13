/*******
 * Read input from STDIN
 * Use printf(...) or fprintf( stdout, ...) to output your result.
 * Use:
 *  localPrint( char* mystring)
 * to display variable in a dedicated area.
 * ***/
#include <stdlib.h>
#include <stdio.h>
#include <stdbool.h>
#include <string.h>

typedef struct  bingo_cell
{
    int         val;
    bool        used;
}               bingo_cell;

bool    check_diag(bingo_cell **board, int x, int y)
{
    int i;

    if ((x + y) == 4)
    {
        for(i = 0; i < 5; ++i)
            if (!board[4 - i][i].used)
                return (false);
        return (true);
    }
    else if (x == y)
    {
        for(i = 0; i < 5; ++i)
            if (!board[i][i].used)
                return (false);
        return (true);
    }
    return (false);
}

bool    check_hor(bingo_cell **board, int y)
{
    int x;

    for(x = 0; x < 5; ++x)
        if (!board[y][x].used)
            return (false);
    return (true);
}

bool    check_vert(bingo_cell **board, int x)
{
    int y;

    for(y = 0; y < 5; ++y)
        if (!board[y][x].used)
            return (false);
    return (true);
}

bool    check_tirage(bingo_cell **board, int x, int y)
{
    if (check_vert(board, x)
        || check_hor(board, y)
        || check_diag(board, x, y))
            return (true);
    return (false);
}

void            get_result()
{
    char        s[1024];
    int         ln;
    int         i;
    int         j;
    int         tirage;
    bool        bingo;
    bingo_cell  **board;

    bingo = false;
    ln = 1;
    board = malloc(sizeof(*board) * 5);
    for(i = 0; i < 5; ++i)
        board[i] = malloc(sizeof(**board) * 5);
    while(!bingo && gets(s) != NULL)
    {
        if (ln <= 5)
        {
            board[ln - 1][0].val = atoi(strtok(s, " "));
            board[ln - 1][0].used = false;
            for(i = 1; i < 5; ++i)
            {
                board[ln - 1][i].val = atoi(strtok(NULL, " "));
                board[ln - 1][i].used = false;
            }
        }
        else if (ln > 6)
        {
            tirage = atoi(s);
            for(i = 0; i < 5; ++i)
                for(j = 0; j < 5; ++j)
                    if (board[i][j].val == tirage)
                    {
                        board[i][j].used = true;
                        if(check_tirage(board, j, i))
                        {
                            bingo = true;
                            printf("OK %i\n", (ln - 6));
                        }
                    }
        }
        ++ln;
    }
    if (!bingo)
        printf("NOK\n");
}

int main()
{
    get_result();
    return (0);
}
