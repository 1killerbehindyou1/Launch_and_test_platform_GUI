/*
 * TypeConwersion.h
 *
 * Created: 1/11/2020 8:36:57 AM
 *  Author: plesn
 */ 


#ifndef TYPECONWERSION_H_
#define TYPECONWERSION_H_
#include <inttypes.h>




char * FloatToChar(float );
float CharToFloat(char * );
char *IntToChar(int);
char *DecToBin(uint8_t);
void PrintIntAsChar(int, int);
uint8_t CharToUint(char * RX_buf);		

#endif /* TYPECONWERSION_H_ */