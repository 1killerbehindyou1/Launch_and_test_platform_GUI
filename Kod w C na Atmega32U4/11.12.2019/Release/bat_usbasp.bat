cd C:\avr_dude

avrdude -p atmega32u4 -c usbasp -P usb -e -U flash:w:"C:\Users\Kolunio\Desktop\1.AVR_OPROGRAMOWANIE\1. Platforma_testowa\0. aplikacja na m32U4\platforma\Release\platforma.hex":i
pause