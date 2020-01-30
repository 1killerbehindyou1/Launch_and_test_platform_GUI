/*
 * CFile1.c
 *
 * Created: 1/11/2020 8:35:59 AM
 *  Author: plesn
 */ 
#include "Parse_Type.h"
#include "uC_UART.h"


#include <math.h>
#include <stdbool.h>
#include <stdlib.h>
#include <inttypes.h>

	char FloatString[16]={};
	char IntegerString[16]={};
	char bin[8]={};

			

char* IntToChar(int integer)										//konwersja typu int na typ char
{
	 bool	flag_minus= false;
	 
		 if(integer < 0)
		 {
			flag_minus= true;	 
			integer *= (-1);
		 }
		 
	 	 if(integer == 0)
	 	 {
			IntegerString[0] = 0;
		 }
		 else
		 {
			  uint8_t reszta;  
			 for(uint8_t ilosc_miejsc_dziesietnych = 0;(integer/= 10)> 10; ilosc_miejsc_dziesietnych++)
			 {
				 reszta = integer % 10;
				 integer = (uint8_t)integer/10;
				 IntegerString[ilosc_miejsc_dziesietnych] = reszta;
			 }
		 }
		
		
		
		
		return IntegerString;
	}
	
char* DecToBin(uint8_t x)								//konwersja typu int na posta? binarn?
{
		
		int i, k;
		

		for (i = 7; i >= 0; i--)
		{
			k = x >> i;

			if (k & 1)
			bin[7-i] = '1';
			else
			bin[7-i] = '0';
		}
		
		return bin;
		
	}
	
char* FloatToChar(float f)									//konwersja typu float na typ char
{
		
		int intPART =(int) 100*f;						//rzutowanie na typ int

		int e= 0,w=100;
		while((intPART/w )>1)							//ustalenie ilosci cyfr w zmiennej pomn o 1
		w *=10;

		

		while(intPART >0)
		{
			if(w==10)
			{

				FloatString[e]= '.';
				e++;
			}
			FloatString[e]=(int)intPART/w + 48;
			intPART -=w*(FloatString[e]-48);

			e++;
			w /=10;

		}
		FloatString[e]= ';';
		FloatString[e +1]= '\0';
		return FloatString;
	}
	
float CharToFloat(char * RX_buf)							//konwersja   typu char na typ float
{
		return atof(RX_buf);
}
	
uint8_t CharToUint(char * RX_buf)
{
		return (uint8_t)atoi(RX_buf);
}				