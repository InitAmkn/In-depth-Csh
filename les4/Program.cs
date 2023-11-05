
//Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу. 
//Подсказка: если взять первое число в массиве, 
//можно ли найти в оставшейся его части два числа равных по сумме первому.


int[] ints = {30,20,7,0,1,7,6,2,1 };
int num = 33;



Console.WriteLine(string.Join(", ", searchForThreeNumbers(num, ints)));


int[] searchForThreeNumbers(int num, int[] ints)
{
    if(ints.Length<3) return new int[] { };
    

    for (int i = 0; i < ints.Length; i++)
    {
        List<int> result = new List<int>();
        int numTemp = num - ints[i];
    
        for (int j = i+1; j < ints.Length; j++)
        {
          int numTemp1 = numTemp - ints[j];
          
            for (int k = j + 1; k < ints.Length; k++)
            {
                int numTemp2 = numTemp1 - ints[k];
                
                if (numTemp2 == 0)
                {    
                    result.Add(ints[i]);
                    result.Add(ints[j]);
                    result.Add(ints[k]);
                    return result.ToArray();
                }
            }
        }
    }
    return new int[] { };
}



