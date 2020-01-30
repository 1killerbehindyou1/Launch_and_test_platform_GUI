/*
 * PCB_Generator.c
 *
 * Created: 1/26/2020 12:21:07 PM
 *  Author: plesn
 */

#include "Command.h"

#include "PCB_Generator.h"
#include "uC_UART.h"
#include "Parse_Type.h"
#include <avr/sfr_defs.h>
#include <avr/io.h>
#include <avr/interrupt.h>
#include <math.h>
#include <stdlib.h>
#include <util/delay.h>
#include <inttypes.h>

#include <stdbool.h>




Generator Gen ={100, 5};

void timer0_init(void)
{
	
	TCCR0 |= (1 << WGM01) | (1 << WGM00);   // wlacz tryb Fast PWM
	TCCR0 |= (1 << COM01);
	OCR0= 255;
	TCNT0 = 0; //ustaw na poczatek

	TIMSK = (1<<TOIE0); //zezwol na przerwanie przy przepelnieniu
}


float GeneratorSin(void)
{
	float val;
	if(Gen.sampling==0)
	{
		TCCR0 &= ~(1<<CS21);
	}
	
		val =5 + Gen.Voltage * sin(k*Gen.sampling);
		Gen.sampling--;
		return val;

} 

void GeneratorSqr(int freq,float voltage,uint8_t duty)
{
	
}
void GeneratorSettings( uint8_t ampl, int freq )
{
	
	
	Gen.freq = freq;
	
	Gen.Voltage = ampl;
}

void GeneratorEnable(bool EN)
{
	Gen.EN = EN;
	Gen.sampling = 100;
if(Gen.EN)
{
	TCCR0 |= (1 << CS21); //Ustawienie dzielnika na 64, po czym sta
}
	else
	{
		TCCR0 |= _BV(CS21); //Ustawienie dzielnika na 64, po czym sta
	}
	
	
}


ISR(TIMER0_OVF_vect){		SerialPrintFloat(GeneratorSin());	}