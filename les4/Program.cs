
//Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу. 
//Подсказка: если взять первое число в массиве, 
//можно ли найти в оставшейся его части два числа равных по сумме первому.


int[] ints = {30,20,7,0,1,7,6,2,1 };
int num = 33;


Console.WriteLine(isHaveSumThreeNumbers(num, ints));


bool isHaveSumThreeNumbers(int num, int[] ints)
{
    if(ints.Length<3) return false;
    
    for (int i = 0; i < ints.Length; i++)
    {
        int numTemp = num - ints[i];
        for (int j = i+1; j < ints.Length; j++)
        {
          int numTemp1 = numTemp - ints[j];
            for (int k = j + 1; k < ints.Length; k++)
            {
                int numTemp2 = numTemp1 - ints[k];
                if (numTemp2 == 0) return true;
            }
        }
    }
    return false;
}



