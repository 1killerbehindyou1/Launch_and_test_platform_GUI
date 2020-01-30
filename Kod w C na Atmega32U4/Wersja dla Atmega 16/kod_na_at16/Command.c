/*
 * CFile1.c
 *
 * Created: 02.07.2019 01:47:25
 *  Author: Kolunio
 */ 
#include "PCB_Generator.h"
#include "Command.h"
#include "Parse_Type.h"
#include "uC_UART.h"
#include "PCB_I2C.h"
#include "uC_ADC.h"

#define F_CPU 3686400UL

#include <inttypes.h>
#include <util/delay.h>
#include <avr/interrupt.h>
#include <stdlib.h>
#include <math.h>
#include <avr/io.h>
#include <stdbool.h>

#define SIGNAL 's'
#define  STAT_OK  OK
//#define		ERR_0
//#define		 ERR_1
//#define		ERR_2
#define	ERR_3 	NOK
//#define		ERR_4

extern Generator Gen;
extern Zasilacz CHANNEL[];
extern circ_buffer buffer_TX;
 KOM command;

void Skan(void)											// Skanowanie parametrow w petli glownej programu	
{
	Skan_all_supply();					
}

void Diagnostics(void)									//selftest wszystkich urzadzen i raport po UART
{	
	Scan_I2C();										//skanowanie i wykrywanie adresów urzadzen I2C
}

void CPU_init(void)										// Inicjalizacja urzadzen wewnetrznych mikrokontrolera, funkcje wysylaja 
{													//Status operaci true/false lub kod bledu
	//config_ext_int();                             //wylaczenie wstepnie zalczonych przerwan od USB 													//przez bootloader  	
	Serial_Init();									//konfiguracja rejestrów odpowiedzialnych za prac? UART
	timer0_init();
	//PWM0_init();
	//adc_init();									//inicjalizacja przetwornika ADC		
	//init_i2C_dev();								 //konfiguracja rejestrów odpowiedzialnych za pracy I2C	
	//pot_init();			
}																

void init_dev_onPCB(void)								// Inicjalizacja urzadzen wewnetrznych mikrokontrolera
{
	command.flag_val =false;
	command.flag_arg =false;
	command.IncomingDataErr = false;
	command.flag_complete = false;
	pot_init();
}

void config_ext_int(void)
{
	/*    //dlaAtmega 32U4
	UHWCON =0;
	USBCON =0;
	UDIEN =0;
	*/
}
					
void UART_raport(char *result)							//utworzenie raportu z poj wyniku pomiaru 
{														//do wyslania i wyslanie do bufora
	 Serial_Print_to_Buff(&buffer_TX, result);					//buforowanie wynikow pomiaru 
}

void Verify()
{
	/**char result_code[]; 
	if(war)
	result_code = OK;
	else
	result_code = NOK;*/
	//SerialPrintSupplyParam(command.arg);   
	SerialPrint("OK;");
}

void UART_Get_command(void)								//pobranie komendy z UART
{
	
	uint8_t RX_buff_counter =0;
		if(command.flag_arg)
		{
			for( RX_buff_counter =0;(command.RX_buf[RX_buff_counter+1] != mark_swich)&& ((command.RX_buf[RX_buff_counter+2] != mark_end)&&(command.RX_buf[RX_buff_counter+2] != mark_val)); RX_buff_counter++)
			{
				command.arg[RX_buff_counter] = command.RX_buf[RX_buff_counter +1];			//przypisanie wartsci do zmiennych arg
			}
			command.arg[RX_buff_counter] = '\0';
			command.flag_arg= false;
		}		
	if(command.flag_val)
	{
		char val_tab[6]={};
		RX_buff_counter +=2;
		for(uint8_t val_tab_ind=0;(command.RX_buf[RX_buff_counter+1] !=mark_swich );RX_buff_counter++)
		{		
			val_tab_ind++;
			val_tab[val_tab_ind] = command.RX_buf[RX_buff_counter+2];			//przypisanie wartoœci do zmiennych arg	
			val_tab[val_tab_ind +1] = '\0';
		}		
		command.value = CharToFloat(val_tab);
		command.flag_val =false;		
	}
	 Decode_command();	
	ClearRX_buf();
}
	
void ClearRX_buf(void)
{
	//SerialPrint("Clear;");
	command.flag_complete =false;
	command.flag_val =false;
	command.flag_arg =false;
	
	for(uint8_t i =0; i<16; i++)
	{
		command.RX_buf[i] ='\0';
		command.arg[i] = '\0';
	}
	command.IncomingDataErr = false;
	command.value = 0;
	command.RecievCharCount= 0;
}	
	
	

void Decode_command(void)								
{
	
	switch(command.arg[device])
	{
			case ZASILACZ_:					//sterowanie kanalami przetfornic
			{				
					if (command.arg[operation] == WYSWIETL)     //1z{kanal}{v,c,p}
					{
						SerialPrintSupplyParam(command.arg);   
					}								
					if(command.arg[operation] == USTAW)    //0z{kanal}{parametr}{1/0}
					{
						uint8_t chann = CharToUint(command.arg[channel]);																		
						if(CHANNEL[chann].EN == true)
						{
								if(command.arg[parameter] == TRYB)
								{
									if(command.arg[4] == '1')        //0z3t1
									{
										CHANNEL[chann].MOD ==  current_source;
										Verify();
									}
									
								
									if(command.arg[4] == '0')			//0z3t0
									{
										CHANNEL[chann].MOD == voltage_source;
											Verify();
									}
									
								}														
								if (command.arg[parameter] == OGRANICZENIE)						// ustawienie ograniczenia pradowego
								{
									// polecenie: 0zc3
									CHANNEL[chann].Current= command.value;
									SetCurr(chann, command.value);
									Verify();
								}						
								if (command.arg[parameter] == NAPIECIE)					 //ustawienie napiecia wysciowego
								{
									// polecenie: 0zv3
									CHANNEL[chann].Voltage= command.value;
									SetVol( chann, command.value);
									Verify();
								}	
						}
						else if(CHANNEL[chann].EN == false)
						{							
							if(command.arg[parameter] == 'e')  
								{
									if(command.arg[4] == '1')   //0z3e1
									{
										CHANNEL[chann].EN == true;
										Verify();
									}
									if(command.arg[4] == '0') //0z3e0;
									{
										CHANNEL[chann].EN ==  false;
										Verify();
									}
								}						
						}
					}
					
				break;
				}
				case GENERATOR:									//ustawianie generatora
				{
					if(command.arg[operation] == USTAW)    //0g{parametr}{vartosc}
					{
						if (command.arg[parameter] == NAPIECIE)						// ustawienie ograniczenia pradowego
						{
									Gen.Voltage = command.value;											// polecenie: 0gv
							
						}
						if (command.arg[parameter] == CZESTOTLIWOSC)						// ustawienie ograniczenia pradowego
						{
																						// polecenie: 0gf
							Gen.freq =command.value;
							
						}
						
					if (command.arg[parameter] == SIGNAL)						// ustawienie ograniczenia pradowego
						{
																					// polecenie: 0gsq
								
						}
						
						if (command.arg[parameter] == ENABLE)						// ustawienie ograniczenia pradowego
						{
							GeneratorEnable(true);						// polecenie: 0ge
							
						}	
						
					}
					break;
				}
				
						
			}
}

				
				/*   NIEZAIPLEMENTOWANE I NIE PRZETESTOWANE
				else if(CHANNEL[(uint8_t)CharToFloat(command.arg[channel])].MOD== current_source)  //Jezeli tryb pracy = ?ród?o pr?dowe
				{
					
					if(command.arg[parameter] == NAPIECIE )					//ustawianie maksymalnego napi?cia
					{
						CHANNEL[(uint8_t)CharToFloat(command.arg[channel])].OvVol = command.value;	
					}
				
					if(command.arg[parameter] == OGRANICZENIE)				//usatawianie pradu zród?a pradowego
					{
					    
					}
				
				}
			
		


			
			case PRZEKAZNIK:									//sterowanie przeka?nikami
			{
				break;
			}	
			case WYJSCIE_ANALOGOWE:									//ustawianie wyjscia analogowego
			{
				break;
			}
			case KOMPARATOR:									//ustawianie komparatorów
			{
				break;
			}
			
			*/



	
		