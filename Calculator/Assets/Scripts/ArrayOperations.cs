using System.Linq;
using TMPro;
using UnityEngine;

public class ArrayOperations : MonoBehaviour
{
	[SerializeField] private TMP_Text result;
	
	/// <summary>
	/// Метод обработки события OnClick кнопки "Сумма четных чисел заданного диапазона"
	/// </summary>
	public void OnSumEvenNumbersInRange()
	{
    	int min = 7;
    	int max = 21;
    	var want = 98;
    	int got = SumEvenNumbersInRange(min, max);
    	string message = want == got ? "Результат верный" : $"Результат неверный, ожидается {want}";
        result.text = $"Сумма четных чисел в диапазоне от {min} до {max} включительно: {got} - {message}";
	}

	/// <summary>
	/// Метод вычисляет сумму четных чисел в заданном диапазоне
	/// </summary>
	/// <param name="min">Минимальное значение диапазона</param>
	/// <param name="max">Максимальное значение диапазона</param>
	/// <returns>Сумма чисел четных чисел</returns>
	private int SumEvenNumbersInRange(int min, int max)
	{
		int resultNum = 0;
		for (int i = min; i < max + 1; i++)
		{
			if (i % 2 == 0)
			{
				resultNum += i;
			}
		}
		
    	return resultNum;
	}

	/// <summary>
	/// Метод обработки события OnClick кнопки "Сумма четных чисел в заданном массиве"
	/// </summary>
	public void OnSumEvenNumbersInArray()
	{
		int[] array = { 81, 22, 13, 54, 10, 34, 15, 26, 71, 68 };
		int want = 214;
		int got = SumEvenNumbersInArray(array);
		string message = want == got ? $"Результат верный: {got}" : $"Результат неверный, ожидается {want}";
		result.text = message;
	}

	/// <summary>
	/// Метод вычисляет сумму четных чисел в массиве
	/// </summary>
	/// <param name="array">Исходный массив чисел</param>
	/// <returns>Сумма чисел четных чисел</returns>
	private int SumEvenNumbersInArray(int[] array)
	{
		int resultNum = 0;
		foreach (int number in array)
		{
			if (number % 2 == 0)
			{
				resultNum += number;
			}
		}
    	return resultNum;
	}


	/// <summary>
	/// Метод обработки события OnClick кнопки "Поиск первого вхождения числа в массив"
	/// </summary>
	public void OnFirstOccurrence()
	{
    	// Первый тест, число присутствует в массиве
    	int[] array = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
    	int value = 34;
    	int want = 3;
    	int got = FirstOccurrence(array, value);
    	string message = want == got ? "Результат верный" : $"Результат неверный, ожидается {want}";
        result.text = $"Индекс первого вхождения числа {value} в массив: {got} - {message} \n";

    	// Второй тест, число не присутствует в массиве
    	array = new int[] { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
    	value = 55;
    	want = -1;
    	got = FirstOccurrence(array, value);
    	message = want == got ? "Результат верный" : $"Результат неверный, ожидается {want}";
        result.text += $"Индекс первого вхождения числа {value} в массив: {got} - {message}";
	}

	/// <summary>
	/// Метод производит поиск первого вхождения числа в массив
	/// </summary>
	/// <param name="array">Исходный массив</param>
	/// <param name="value">Искомое число</param>
	/// <returns>Индекс искомого числа в массиве или -1 если число отсутствует</returns>
	private int FirstOccurrence(int[] array, int value)
	{
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == value)
				return i;
		}

		return -1;
	}

	/// <summary>
	/// Метод обработки события OnClick кнопки "Сортировка выбором"
	/// </summary>
	public void OnSelectionSort()
	{
    	int[] originalArray = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        var initArray = "[" + string.Join(",", originalArray) + "]";
        result.text = $"Исходный массив {initArray}\n";

    	int[] sortedArray = SelectionSort((int[])originalArray.Clone());
        var resultArray = "[" + string.Join(",", sortedArray) + "]";
        result.text += $"Результат сортировки {resultArray}\n";

    	int[] expectedArray = { 10, 13, 15, 22, 26, 34, 34, 68, 71, 81 };
        result.text += sortedArray.SequenceEqual(expectedArray) ? "Результат верный" : "Результат не верный";
	}

	/// <summary>
	/// Метод сортируем массив методом выбора
	/// </summary>
	/// <param name="array">Исходный массив</param>
	/// <returns>Отсортированный массив</returns>
	private int[] SelectionSort(int[] array)
	{
		for (int i = 0; i < array.Length - 1; ++i)
		{
			int min = i;
			for (int j = i + 1; j < array.Length; ++j)
			{
				if (array[j].CompareTo(array[min]) < 0)
				{
					min = j;
				}
			}
	        
			(array[i], array[min]) = (array[min], array[i]);
		}
	    
		return array;
	}
}
