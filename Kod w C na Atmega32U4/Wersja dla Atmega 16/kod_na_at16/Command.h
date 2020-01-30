/*
 * IncFile1.h
 *
 * Created: 02.07.2019 01:43:34
 *  Author: Kolunio
 */ 



//********************definicje znaków dla komendy*********************//
/*
Format polecenia:
*.../ - komenda liczbowa
#.../ - komenda sterujaca
*/
#define USTAW '0'
#define WYSWIETL '1'


#define ZASILACZ_ 'z'	
#define GENERATOR 'g'
#define WYJSCIE_ANALOGOWE 'a'
#define KOMPARATOR 'k'
#define PRZEKAZNIK 'r'

	
	#define SIGNAL 's'
	#define CZESTOTLIWOSC 'f'
	
	#define OGRANICZENIE 'c'
	#define NAPIECIE 'v'
	#define TRYB 't'
	#define ENABLE 'e'
	#define MOC 'p'
	#define SIN 'b'
	#define SQR 'q'


#define SINUS 0
#define SQR 1
#define TRIA 2


#define operation 0
#define device 1
#define parameter 2
#define channel 3

#define mark_arg '#'
#define mark_val '*'
#define mark_swich '/'
#define mark_end ';'

#define END_OF_TAB '\0'

/*
polecenie.arg[0] == polecenie.arg[operation]
polecenie.arg[1]== polecenie.arg[device]
polecenie.arg[2]== polecenie.arg[parameter]
polecenie.arg[3]==	polecenie.arg[channel]
...
polecenie.arg[n]== pola pomocnicze

//kody komend
***************************************************

Budowa komendy:
arg1 - typ operacji
arg2 - peryferia ktorego dotyczy
arg3 - dodatkowy arg
arg4 - dodatkowy arg
ka¿dy rozkaz sk³ada siê z 4 argumentów + znacznik pocz¹tku i koñca
po rozkazie nastepuje przes³anie wartoœci do zapisu (w przypadku USTAW lub nie w przypadku WYSLIJ
*********************************************************/


#include <util/delay.h>
#include "PCB_PowSupply.h"
#include <stdbool.h>

typedef struct {
		
	float value;
	char arg[6];
	char RX_buf[15];
	uint8_t RecievCharCount;
	bool flag_arg;
	bool  flag_val;
	bool  IncomingDataErr;
	bool flag_complete;	
}KOM;

void Verify();
void config_ext_int(void);
void init_dev_onPCB(void);
void CPU_init(void); 
void Diagnostics(void);
void Skan(void);   
void UART_raport(char *result); 
void UART_Get_command(void);          
void Decode_command(void);
void ClearRX_buf(void);
