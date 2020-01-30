/*
 * uart.h
 *
 * Created: 02.07.2019 08:05:25
 *  Author: Kolunio
 */ 

#include <avr/sfr_defs.h>
#include <avr/io.h>

#ifndef UART_H_
#define UART_H_
#define F_CPU 3686400UL
	#define BAUD 9600										//domyslna dla mod bluetooth
#define baud_setting  ((F_CPU / (16UL * BAUD)) - 1)
#define ROZMIAR 256			//wielkosc bufora cyklicznego

							
#define	UART_BAUD_RATE_LOW			UBRR1L
	#define	UART_STATUS_REG				UCSR1A
	#define	UART_CONTROL_REG			UCSR1B
	#define	UART_ENABLE_TRANSMITTER		TXEN1
	#define	UART_ENABLE_RECEIVER		RXEN1
	#define	UART_TRANSMIT_COMPLETE		TXC1
	#define	UART_RECEIVE_COMPLETE		RXC1
	#define	UART_DATA_REG				UDR1
	#define	UART_DOUBLE_SPEED			U2X1

typedef struct  {
	 char *buffer_pointer;
	uint8_t begin;
	uint8_t end;
}circ_buffer;									//struktura dla typu bufor_cykliczny

uint8_t Serial_TX_BufferWriteIn( circ_buffer* ,char ); //dopisuje dana do bufora 
void SerialTX_BufferSend(circ_buffer* );		//wys?a zaw. bufora po UART
void Serial_Print_to_Buff( circ_buffer* , char *);		//drukuje do wskazanego bufora
void SerialPrintHexByte(unsigned char );
void SerialPrintNewLine(void);
void SerialPrintMESSAGES(const void *, unsigned char );
void SerialClearRX(void);
void SerialSendByte(char );							//elementarna funkcja funkcja drukuje znak
void SerialPrint(char *);							//drukuje string bez buforowania
void SerialPrintFloat(float );						//drukuje vartosc float bez buforowania
void Serial_Init(void);					
void SerialPrintReg(uint8_t,char*);
void PrintAllReg(void);

void SerialPrintSupplyParam(char* param);
#endif /* UART_H_ */