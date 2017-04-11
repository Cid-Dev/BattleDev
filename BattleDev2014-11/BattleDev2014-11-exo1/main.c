/*******
 * Read input from STDIN
 * Use printf(...) or fprintf( stdout, ...) to output your result.
 * Use:
 *  localPrint( char* mystring)
 * to display variable in a dedicated area.
 * ***/
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

int         main()
{
    char    s[1024];
    char    *needle;
    char    *haystack;
    unsigned int     i;
    unsigned int     j;

    scanf("%s", &s);
    needle = malloc(sizeof(char) * strlen(s) + 1);
    needle = strcpy(needle, s);
    scanf("%s", &s);
    haystack = malloc(sizeof(char) * strlen(s) + 1);
    haystack = strcpy(haystack, s);
    i = 0;
    j = 0;
    while (needle[i] && haystack[j])
        if (needle[i] == haystack[j++])
            i++;
    if (i >= strlen(needle))
        printf("OK\n");
    else
        printf("NOK %u\n", i);
    return (0);
}
