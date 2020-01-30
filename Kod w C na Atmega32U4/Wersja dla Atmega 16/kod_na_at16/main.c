
#include <stdbool.h>
#include <avr/interrupt.h>
#include <avr/io.h>
#include <util/delay.h> 
#include "Command.h"
#include "uC_UART.h"

extern circ_buffer buffer_TX;
extern KOM command;

int main(void)
{	
CPU_init(); 
init_dev_onPCB();
//Diagnostics();
sei();	

    while (1) 				
	{	
		//Skan();
	}	
	
return 0;
}

ISR(USART_RXC_vect)								//Przerwanie od przychodzacej komendy wyw. gdy dana w UDR
{	
command.RX_buf[command.RecievCharCount]= UDR;
	if(command.RX_buf[command.RecievCharCount] == '<')
	{		
		ClearRX_buf();
	}
	else
	{
		switch(command.RecievCharCount)
		{
				case 0:
				{
					command.RecievCharCount++;
					if(command.RX_buf[0] != mark_arg)		//sprawdzanie poprawnosci odebran
					{
					//SerialPrint("Error_0;");
					command.IncomingDataErr = true;
					}
				
					break;		
				 }
	
				case 1 :
				case 2 :
				{
					command.RecievCharCount++;	
					break;
				}
				case 3 :
				case 4 :
				case 5 : 
				case 6 :
				case 7 :
				case 8 :
				case 9 :
				{
					 if((command.flag_arg == false)&&	(command.RecievCharCount == 9) && ((command.RX_buf[8] !=mark_swich) &&	((command.RX_buf[8] !=mark_end)&&(command.RX_buf[8] !=mark_val)))	)
					{
						//SerialPrint("Error_1;");
						command.IncomingDataErr = true;
						break;
						
					}
				}
				case 10 :
				case 11 :
				case 12 :
				case 13 :
				case 14 :
				{
					
					if((command.RX_buf[command.RecievCharCount-1] == mark_swich)&&(command.RX_buf[command.RecievCharCount] == mark_val))
					{						
						command.flag_arg =true;
					}
						if(		(command.RX_buf[command.RecievCharCount-1] == mark_swich)&&(command.RX_buf[command.RecievCharCount] == mark_end)	&&	((command.flag_arg ==false)&&(command.flag_val==false))	)
						{													
							command.flag_arg =true;
							command.flag_complete = true;							
							break;					
						}
			
						if(	(command.RX_buf[command.RecievCharCount-1] == mark_swich)&&(command.RX_buf[command.RecievCharCount] == mark_end)&&(command.flag_complete== false)	)
						{							
							command.flag_val =true;
							command.flag_complete = true;
							break;
						}
					
				command.RecievCharCount++;
					break;
				}
						
				case  15 :
							{
								//SerialPrint("Error_2;");
								command.IncomingDataErr = true;
								break;
							}			
					}
					
					if(command.IncomingDataErr)
					{
						//SerialPrint("Error_3;");
						ClearRX_buf();
					}
					 if(	((command.flag_arg && command.flag_val)||(command.flag_arg && !command.flag_val ) )	&&	(command.flag_complete)	&&	(!command.IncomingDataErr))
					{						
						UART_Get_command();						
					}
		}
	
}
