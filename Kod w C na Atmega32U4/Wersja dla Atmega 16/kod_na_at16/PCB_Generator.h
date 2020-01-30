/*
 * IncFile1.h
 *
 * Created: 1/26/2020 12:20:13 PM
 *  Author: plesn
 */ 


#ifndef INCFILE1_H_
#define INCFILE1_H_

#include <avr/sfr_defs.h>
#include <avr/io.h>
#include <stdbool.h>

#define k  2*3.14/Gen.freq
typedef struct {
	
	int freq;
	float Voltage;	
	bool EN;					//1 vw?aczony, 0 wy?
	uint8_t MOD;
		uint8_t duty;	
	float Current;				
	float PowMax;				// Maksymalna Moc dostarczana przez kana?
	int sampling;
	
}Generator;



Generator Gen;
 void GeneratorSettings(uint8_t , int );
float GeneratorSin(void);
 void GeneratorSettings( uint8_t , int);
 void GeneratorEnable(bool);

#endif /* INCFILE1_H_ */