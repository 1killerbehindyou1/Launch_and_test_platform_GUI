/*
 * uart.c
 *
 * Created: 02.07.2019 08:05:09
 *  Author: Kolunio
 */ 


#include "Command.h"

#include "uC_UART.h"
#include "Parse_Type.h"
#include <avr/sfr_defs.h>
#include <avr/io.h>
#include <avr/interrupt.h>
#include <math.h>
#include <stdlib.h>
#include <util/delay.h>
#include <inttypes.h>


char TX_buf_scan[ROZMIAR];
circ_buffer buffer_TX={TX_buf_scan,0,0};	
extern KOM command;						//tablica dla bufora cykliczego
extern Zasilacz CHANNEL[];

void Serial_Print_to_Buff(circ_buffer* q, char text[])
{
	unsigned int i;
	i = 0;
	while ( text[i] != 0 )
	{
	Serial_TX_BufferWriteIn(q, text[i]);
		i++;
	}


}

uint8_t Serial_TX_BufferWriteIn(circ_buffer  *q, char data)
{
	uint8_t head_temp = q->begin + 1;			// Przypisujemy do zmiennej nastepny indeks
	
													// Sprawdzamy czy jest miejsce w buforze.
													// Jezeli bufor jest pelny to wysylamy
	if ( head_temp == q->end )
	{
								
		SerialTX_BufferSend(q);
		return 1;									//wys?ano zaw bufora
	}


	if ( head_temp == ROZMIAR )
	head_temp = 0;
	
												//jest miejsce w buf
	q->buffer_pointer[head_temp] = data;	// Wpisujemy wartoœæ do bufora
	q->begin = head_temp;				// Zapisujemy nowy indeks head o 1 wiekszy
	
	
	return 0;								//bufor nie zosta? jescze oprozniony
}

void SerialTX_BufferSend(circ_buffer *q)
{
	while(q->begin != q->end)
	{
		q->end++;							 // Inkrementujemy indeks tail
		
												// Je?li by? to ostatni element tablicy
													//to ustawiamy wskaznik na jej pocz?tek
		if (q->end ==ROZMIAR)
		q->end = 0;
		
		
		SerialSendByte(q->buffer_pointer[q->end]);		// Odczytujemy wartosc z bufora
	}
	
}


void SerialPrint(char text[]) 
{

	unsigned int i;
	i = 0;
	while ( text[i] != 0 )
	{
		 SerialSendByte( text[i]);
		i++;
	}

}

void SerialSendByte( char c) 
{
	while(!(UCSRA &(1<<UDRE)));
	UDR = c;
}

void SerialClearRX(void)
{
	for(uint8_t i=0;i<12;i++)
	command.RX_buf[i] = 0;
}

void Serial_Init(void)
	{
		
		UBRRH =(unsigned char) (baud_setting >> 8);        //wpisanie starszego bajtu
		UBRRL = (unsigned char) baud_setting;             //wpisanie mlodszego bajtu
		UCSRB = (1<<RXCIE)|(1<<RXEN)|(1<<TXEN);                 //aktywne przerwanie od odbioru oraz zmiana trybu dzia?ania pinów D0 i D1
		UCSRC = (1 << URSEL)|(1 << UCSZ0) | (1 << UCSZ1);     //praca synchroniczna, brak kontroli parzysto?ci, 1 bit stopu, 8 bitów danych
	 
														//zmiana trybu dzia?ania pinów D0 i D1
		
		/*UCSZ0 =1,   UCSZ1 = 1   - liczba bitów danych : 8
		
		//(3<<UCSZ10)  ; (1 << URSEL)
		//synchro  oraz brak kontroli parzystoœci, 1 bit stopu, 8 bitów danych
		 W³¹czenie przerwania, gdy bufor nadawczy pusty */
		
	}

void SerialPrintFloat(float ff)  
{
	SerialPrint(FloatToChar(ff));
	
} 

/*	
void rsPrintReg(uint8_t reg, char name[])
{
	rsPrint(name);
	rsPrint("=\t");
	rsPrint(decToBin(reg));
	
	PrintNewLine();
}
*/
void PrintAllReg(void)
	{
		/*rsPrintReg(MCUSR, "MCUSR");
		rsPrintReg(WDTCSR,"WDTCSR");
		rsPrintReg(MCUCR,"MCUCR");
		rsPrintReg(EIMSK,"EIMSK");
		rsPrintReg(TIMSK0,"TIMSK0");
		rsPrintReg(TIMSK1,"TIMSK1");
		rsPrintReg(TIMSK3,"TIMSK3");
		rsPrintReg(PCICR,"PCICR");*/
		//rsPrintReg(UDIEN ,"UDIEN");
		/*rsPrintReg(PINC,"PINC");
		rsPrintReg(PIND,"PIND");
		rsPrintReg(PINE,"PINE");
		rsPrintReg(PINF,"PINF");*/
		//rsPrintReg(TIFR1,"TIFR1");
		//rsPrintReg(TIFR3,"TIFR3");
		//rsPrintReg(TIFR4,"TIFR4");
		//rsPrintReg(EIFR,"EIFR");
		//rsPrintReg(TCCR0A,"TCCR0A");
		//rsPrintReg(TCCR0B,"TCCR0B");
		//rsPrintReg(TCNT0,"TCNT0");
		//rsPrintReg(PCMSK0,"PCMSK0");
		/*rsPrintReg(USBINT,"USBINT");
		rsPrintReg(USBCON,"USBCON");
		rsPrintReg(USBSTA,"USBSTA");
		rsPrintReg(UHWCON,"UHWCON");*/
		
		
	}		
	
void SerialPrintNewLine(void)
{
	SerialPrint("\n\r");
}

/*
void	PrintMESSAGES(const void *dataPtr, unsigned char offset)
{
char	theChar;

	dataPtr		+=	offset;

	do {
	
		theChar	=	pgm_read_byte_near((uint16_t)dataPtr++);
	
		if (theChar != 0)
		{
			sendchar(theChar);
		}
	} while (theChar != 0);
}
*/


/*	
void	PrintHexByte(unsigned char theByte)
{
	
char	theChar;

	theChar	=	0x30 + ((theByte >> 4) & 0x0f);
	if (theChar > 0x39)
	{
		theChar	+=	7;
	}
	sendchar(theChar );

	theChar	=	0x30 + (theByte & 0x0f);
	if (theChar > 0x39)
	{
		theChar	+=	7;
	}
	sendchar(theChar );
}

*/	

void SerialPrintUniwersal()
{
	
}




void SerialPrintSupplyParam(char* param)   //sk?adnia pola command.arg: 1z{kana?}{v,c,p}
{
	
	
	
	uint8_t nr =  CharToUint(param[2]);
	SerialPrint("CH:");
	SerialSendByte(param[2]);
	SerialSendByte(';');
	int i =3;
	
	while (param[i] != '\0')
	{
		if( param[i] == 'v') 
		{
			//SkanVol(nr);
			SerialPrintFloat(CHANNEL[nr].Voltage);
			SerialPrint("V;");
			
		}
		if(param[i] == 'c') 
		{
			//SkanCurr(nr);
			SerialPrintFloat(CHANNEL[nr].Voltage);
			SerialPrint("mA;");
			
		}
		if(param[i] == 'p') 
		{
			//CheckOvPower(nr);
			SerialPrintFloat(CHANNEL[nr].Voltage);
			SerialPrint("W;");
			
		}
		
		if(param[i] == 'm')
		{
			if(CHANNEL[nr].EN)
			SerialPrint("Enable;");
			else
			SerialPrint("Disable;");
		}
		i++;
	}
	SerialPrint("\n\r");
	
}