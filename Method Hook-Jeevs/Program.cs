using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_Hook_Jeevs
{
    internal class Program
    {
        public static double Q(double x1,double x2)
        {
            return (1 - x1)* (1 - x1) + 100 * (x2 - x1 * x1) * (x2 - x1 * x1);
        }
        public static double[] foundingSearch(double x1,double x2,double h)
        { 
            double x1l, x1r, x2l, x2r;
            double xp1 = 0, xp2 = 0;
            double e = 0.0001;
            double functionx = 0;
            double functionx1l = 0;
            double functionx2l = 0;
            double functionx1r = 0;
            double functionx2r = 0;
            double[] answer= new double[3];
            xp1 = x1;
            xp2 = x2;
            x1l = x1 - h;
            x1r = x1 + h;
            x2l = x2 - h;
            x2r = x2 + h;
            functionx = Q(x1, x2);
            functionx1l = Q(x1l, x2);
            functionx1r = Q(x1r, x2);
            if (functionx1l < functionx1r)
            {
                if (functionx1l < functionx)
                {
                    x1 = x1l;
                    functionx2l = Q(x1, x2l);
                    functionx2r = Q(x1, x2r);
                }
                if (functionx1l == functionx)
                {
                    h = h * 0.1;
                }
            }
            else
            {
                if (functionx1r==functionx)
                {
                    h=h*0.1;
                }
                if (functionx1r < functionx)
                {
                    x1 = x1r;
                    functionx2l = Q(x1, x2l);
                    functionx2r = Q(x1, x2r);
                }
                
            }
            if (functionx2l < functionx2r)
            {
                if (functionx2l < functionx)
                {
                    x2 = x2l;
                    functionx1l = Q(x1l, x2);
                    functionx1r = Q(x1r, x2);
                }
                if (functionx1l == functionx)
                {
                    h = h * 0.1;
                }
            }
            else
            {
                if (functionx2r == functionx)
                {
                    h = h * 0.1;
                }
                if (functionx2r < functionx)
                {
                    x2 = x2r;
                    functionx1l = Q(x1l, x2);
                    functionx1r = Q(x1r, x2);
                }

            }
            answer[0] = x1;
            answer[1] = x2;
            answer[2] = h;
            return answer;


        }
        public static double[] foundingSearchWithoutH(double x1, double x2,double h)
        {
            double x1l, x1r, x2l, x2r;
            double xp1 = 0, xp2 = 0;
            double e = 1e-05;
            double functionx = 0;
            double functionx1l = 0;
            double functionx2l = 0;
            double functionx1r = 0;
            double functionx2r = 0;
            double[] answer = new double[2];
            xp1 = x1;
            xp2 = x2;
            x1l = x1 - h;
            x1r = x1 + h;
            x2l = x2 - h;
            x2r = x2 + h;
            functionx = Q(x1, x2);
            functionx1l = Q(x1l, x2);
            functionx1r = Q(x1r, x2);
            if (functionx1l < functionx1r)
            {
                if (functionx1l < functionx)
                {
                    x1 = x1l;
                    functionx2l = Q(x1, x2l);
                    functionx2r = Q(x1, x2r);
                }
            }
            else
            {
                
                if (functionx1r < functionx)
                {
                    x1 = x1r;
                    functionx2l = Q(x1, x2l);
                    functionx2r = Q(x1, x2r);
                }

            }
            if (functionx2l < functionx2r)
            {
                if (functionx2l < functionx)
                {
                    x2 = x2l;
                    functionx1l = Q(x1l, x2);
                    functionx1r = Q(x1r, x2);
                }
            }
            else
            {
                if (functionx2r < functionx)
                {
                    x2 = x2r;
                    functionx1l = Q(x1l, x2);
                    functionx1r = Q(x1r, x2);
                }

            }
            answer[0] = x1;
            answer[1] = x2;
            return answer;


        }
        public static double[] sampleSearch(double firstx1, double firstx2, double secondx1,double secondx2)
        {
            double[] answer = new double[2];
            double thirdx1=0;
            double thirdx2=0;
            double lyambda = 2;
            thirdx1 = firstx1 - lyambda * (secondx1 - firstx1);
            thirdx2 = firstx2 - lyambda * (secondx2 - firstx2);
            answer[0] = thirdx1;
            answer[1] = thirdx2;
            return answer;

        }
        static void Main(string[] args)
        {
            int step = 0;
            double x1=3, x2=2;
            double secondx1=0, secondx2=0, thirdx1=0, thirdx2=0, fourthx1=0, fourthx2=0; 
            double h = 1;
            double e = 1e-05;
            double functionx=0;
            double functionx1l = 0;
            double functionx2l = 0;
            double functionx1r = 0;
            double functionx2r = 0;
            double[] currentAnswerSearch = new double[3];
            double[] currentAnswerSearchWithoutH = new double[2];
            double[] currentAnswerSampleSearch = new double[2];
            bool flag=true ;
            while (h>e)
            {
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Значение целевой функции на шаге {0}",step);
                Console.WriteLine("x=({0};{1}),f(x)={2}", x1, x2, Q(x1, x2));
                Console.WriteLine("------------------------------------------------");
                Console.ReadKey();
                currentAnswerSearch = foundingSearch(x1, x2, h);
                h = currentAnswerSearch[2];
                secondx1 = currentAnswerSearch[0];
                secondx2 = currentAnswerSearch[1];
                currentAnswerSampleSearch = sampleSearch(x1, x2, secondx1, secondx2);
                thirdx1= currentAnswerSampleSearch[0];
                thirdx2 = currentAnswerSampleSearch[1];
                currentAnswerSearchWithoutH = foundingSearchWithoutH(thirdx1, thirdx2, h);
                fourthx1 = currentAnswerSearchWithoutH[0];
                fourthx2 = currentAnswerSearchWithoutH[1];
                if ((fourthx1!=thirdx1)&&(fourthx2!=thirdx2))
                {
                    while(flag)//то точку 2 переобозначим на 1, а 4 на 2 и повторим поиск по образцу
                    {
                        x1 = secondx1;
                        x2 = secondx2;
                        secondx2 = fourthx2;
                        secondx1 = fourthx1;
                        currentAnswerSampleSearch = sampleSearch(x1, x2, secondx1, secondx2);
                        thirdx1 = currentAnswerSampleSearch[0];
                        thirdx2 = currentAnswerSampleSearch[1];
                        currentAnswerSearchWithoutH = foundingSearchWithoutH(thirdx1, thirdx2, h);
                        fourthx1 = currentAnswerSearchWithoutH[0];
                        fourthx2 = currentAnswerSearchWithoutH[1];
                        if ((fourthx1 != thirdx1) && (fourthx2 != thirdx2))
                        {
                            flag = false;
                        }

                    }
                    flag = true;
                }
                else//В случае если не удаётся найти точку 4, отличную от точки 3, то точку 2 переобозначим на точку 1 и повторим 1-ю фазу алгоритма — исследующий поиск.
                {
                    x1 = secondx1;
                    x2 = secondx2;
                }


                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("ШАГ {0}",step);
                Console.WriteLine("Перечислим все точки и значений функции в этих точках");
                Console.WriteLine("x=({0};{1}),f(x)={2}", x1, x2, Q(x1, x2));
                Console.WriteLine("x=({0};{1}),f(x)={2}", secondx1, secondx2, Q(secondx1, secondx2));
                Console.WriteLine("x=({0};{1}),f(x)={2}", thirdx1, thirdx2, Q(thirdx1, thirdx2));
                Console.WriteLine("x=({0};{1}),f(x)={2}", fourthx1, fourthx2, Q(fourthx1, fourthx2));
                Console.WriteLine("------------------------------------------------");
                step++;
                Console.ReadKey();



            }
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("РЕЗУЛЬТАТЫ");
            Console.WriteLine("Перечислим все точки и значений функции в этих точках");
            Console.WriteLine("x=({0};{1}),f(x)={2}",x1,x2,Q(x1,x2));
            Console.WriteLine("x=({0};{1}),f(x)={2}", secondx1, secondx2, Q(secondx1, secondx2));
            Console.WriteLine("x=({0};{1}),f(x)={2}", thirdx1, thirdx2, Q(thirdx1, thirdx2));
            Console.WriteLine("x=({0};{1}),f(x)={2}", fourthx1, fourthx2, Q(fourthx1, fourthx2));
            Console.WriteLine("------------------------------------------------");
            Console.ReadKey();


        }
    }
}
