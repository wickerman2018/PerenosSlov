# PerenosSlov
Програма для автоматичного розставляння переносів у тексті.

## Перенесення слів ##
Як показують численні експерименти , розбиття українського слова на частини для переносу з одного рядка на інший з великою ймовірністю виконуються правильно, якщо користуватися наступними простими прийомами:
1. Дві, що йдуть підряд голосні можна розділити, якщо перед першою з них розташована приголосна, а за другою йде хоча б одна літера ( літера й при цьому розглядається разом з попередньою голосною як складне ціле).
2. Дві, що йдуть підряд приголосні можна розділити, якщо перед першою з них розташована голосна, а в тій частині слова, яка йде за другою приголосною, є хоча б одна голосна.
3. Якщо не вдається застосувати пункти 1 та 2, то слід спробувати розбити слово так, щоб перша частина містила більш ніж одну літеру  і закінчувалася на голосну, а друга містила хоча б одну голосну. Ймовірність правильного розбиття збільшується, якщо попередньо скористатися хоча б неповним списком приставок, що містять голосні, і спробувати насамперед виділити у слові таку приставку.
