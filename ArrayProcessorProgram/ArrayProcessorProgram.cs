using System;

namespace ArrayProcessorProgram;

// ===== LỚP XỬ LÝ LOGIC CHÍNH =====
public class ArrayProcessor
{
    // Một thuộc tính private để lưu trữ mảng dữ liệu
    // private có nghĩa là chỉ có thể truy cập được từ bên trong lớp này
    private int[] data;

    // Các phương thức (Input, Display, Sort, Search...) sẽ được thêm vào đây
    public void Input()
    {
        Console.WriteLine("Nhap kich co cua mang: ");
        int size = int.Parse(Console.ReadLine());
        this.data = new int[size];
        for (int i = 0; i < size; i++)
        {
            Console.Write($"data[{i}] = ");
            data[i] = int.Parse(Console.ReadLine());
        }
    }

    public void Display()
    {
        if(data == null || data.Length == 0)
        {
            Console.WriteLine("Mang rong");
            return;
        }
        Console.WriteLine("[" + string.Join(", ", this.data) + "]");

    }
    //bubble sort
    public void BubbleSort()
    {
        int n = this.data.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (this.data[j] > this.data[j + 1])
                {
                    int temp = this.data[j];
                    this.data[j] = this.data[j + 1];
                    this.data[j + 1] = temp;
                }
            }
        }
    }

    public void QuickSort()
    {
        QuickSortRecursive(0, this.data.Length - 1);
    }

    public void QuickSortRecursive(int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(left, right); 
            QuickSortRecursive(left, pivot - 1);
            QuickSortRecursive(pivot + 1, right);
        }
    }

    private int Partition(int left, int right)
    {
        int pivot = this.data[right];
        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (this.data[j] <= pivot)
            {
                i++;
                //exchange data[i] and data[j]
                (this.data[i], this.data[j]) = (this.data[j], this.data[i]);
            }
        }
        (this.data[i + 1], this.data[right]) = (this.data[right], this.data[i + 1]);
        return i + 1;
    }
    // linear search 
    public int LinearSearch(int key)
    {
        for (int i = 0; i < this.data.Length; i++)
        {
            if (this.data[i] == key)
            {
                return i;
            }
        }
        return -1;
    }

    public int BinarySearch(int key)
    {
        int left = 0;
        int right = this.data.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (this.data[mid] == key)
            {
                return mid;
            }
            else if (this.data[mid] < key)
            {
                left = mid + 1;
            } else
                right = mid - 1;
        }
        return -1;
    }
    
}

// ===== LỚP CHẠY CHƯƠNG TRÌNH =====
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- CHUONG TRINH SAP XEP VA TIM KIEM ---");
        //input array
        ArrayProcessor arrayProcessor = new ArrayProcessor();
        arrayProcessor.Input();
        //display array
        arrayProcessor.Display();
        //bubble sort
        arrayProcessor.BubbleSort();
        Console.WriteLine("Bubble sort: ");
        arrayProcessor.Display();
        //quick sort
        arrayProcessor.QuickSort();
        Console.WriteLine("Quick sort: ");
        arrayProcessor.Display();
        //choosing between Linear search or Binary Search
        string choice = Console.ReadLine();
            Console.WriteLine("Nhap key: ");
            int key = int.Parse(Console.ReadLine());
            int index = arrayProcessor.LinearSearch(key);
            if (index == -1)
            {
                Console.WriteLine("Khong tim thay");
            }
            else
            {
                Console.WriteLine($"Key {key} co index {index}");
            }
            Console.WriteLine("Nhap key: ");
            key = int.Parse(Console.ReadLine());
            index = arrayProcessor.BinarySearch(key);
            if (index == -1)
            {
                Console.WriteLine("Khong tim thay");
            }
            else
            {
                Console.WriteLine($"Key {key} co index {index}");
            }
        
        
    }
}