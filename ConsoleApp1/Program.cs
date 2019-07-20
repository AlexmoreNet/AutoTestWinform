
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace ConsoleApplication1
{
    class Point
    {
        public int X;
        public int Y;
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    class Class1
    {
        static void matrixRotation(List<List<int>> matrix, int r)
        {

            int height = matrix[0].Count;
            int[][] lis = new int[matrix.Count][];
            for (int i = 0; i < matrix.Count; i++)
            {
                lis[i] = new int[height];
            }
            List<List<Point>> list = GetXYgrouop(matrix);
            for (int i = 0; i < list.Count; i++)
            {
                List<Point> p = list[i];
                for (int j = 0; j < p.Count; j++)
                {
                    int newxy = 0;
                    if (j + r >= p.Count)
                    {
                        newxy = (j + r) % p.Count;
                    }
                    else
                    {
                        newxy = (j + r);
                    }
                    Point oldpt = p[j];
                    Point newpt = p[newxy];
                    lis[newpt.Y][newpt.X] = matrix[oldpt.Y][oldpt.X];
                }
            }
            foreach (int[] ll in lis)
            {
                string output = "";
                foreach (int num in ll)
                {
                    output += num + " ";
                }
                Console.WriteLine(output);
            }
        }
        static List<List<Point>> GetXYgrouop(List<List<int>> matrix)
        {
            List<List<Point>> list = new List<List<Point>>();
            int height = matrix.Count();
            int length = matrix[0].Count();

            int count = height / 2;
            int count2 = length / 2;



            int minx = 0;
            int maxx = length - 1;
            for (int a = 0; a < count; a++)
            {
                int miny = 0 + a;
                int maxy = height - a - 1;
                List<Point> newl = new List<Point>();
                int y = miny;
                int x = minx;
                if (miny >= maxy)
                {
                    break;
                }
                if (minx >= maxx)
                {
                    break;
                }
                while (x == minx && y <= maxy)
                {
                    newl.Add(new Point(x, y));
                    if (y != maxy)
                    {
                        y++;
                    }
                    else
                    {
                        x++;
                        break;
                    }
                }
                while (x <= maxx && y == maxy)
                {
                    newl.Add(new Point(x, y));
                    if (x < maxx)
                    {
                        x++;
                    }
                    else
                    {
                        y--;
                        break;
                    }
                }
                while (x == maxx && y >= miny)
                {
                    newl.Add(new Point(x, y));
                    if (y > miny)
                    {
                        y--;
                    }
                    else
                    {
                        x--;
                        break;
                    }
                }
                while (x > minx && y == miny)
                {
                    newl.Add(new Point(x, y));
                    if (x > minx)
                    {
                        x--;
                    }
                    else
                    {
                        break;
                    }
                }
                minx++;
                maxx--;
                list.Add(newl);
            }
            return list;
        }

        static void almostSorted(int[] arr)
        {
            bool isok = true;
            List<int> list = arr.ToList<int>();
            List<int> dilist = new List<int>();
            list.Sort();
            int diff = 0;
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i] != arr[i])
                {
                    dilist.Add(i + 1);
                    diff++;
                }

            }
            if (diff == 2)
            {
                Console.WriteLine("yes");
                Console.WriteLine("swap " + dilist[0] + " " + dilist[1]);
            }
            else if (diff > 2)
            {

                List<int> list2 = arr.ToList<int>();
                int count = dilist[dilist.Count() - 1] - dilist[0] + 1;
                list2.Reverse(dilist[0] - 1, count);

                for (int i = dilist[0] - 1; i < dilist[dilist.Count() - 1]; i++)
                {
                    if (list[i] != list2[i])
                    {
                        isok = false;
                        break;
                    }
                }
                if (isok)
                {
                    Console.WriteLine("yes");
                    Console.WriteLine("reverse " + dilist[0] + " " + dilist[dilist.Count() - 1]);
                }
                else
                {
                    Console.WriteLine("no");
                }
            }

        }
        static string appendAndDelete(string s, string t, int k)
        {
            var minLength = Math.Min(s.Length, t.Length);
            int pnum = -1;
            for (int i = 0; i < minLength; i++)
            {
                if (s[i] != t[i])
                {
                    pnum = i;
                    break;
                }
            }
            int count = s.Length - pnum + t.Length - pnum;
            if (k == count || (k - count > 0 && (k - count) % 2 == 0) || k >= count + 2 * pnum)
                return "Yes";
            return "No";
        }
        static int squares(int a, int b)
        {
            int count = 0;
            int min = (int)Math.Sqrt(a);

            while (Math.Pow(min, 2) <= b)
            {
                if (Math.Pow(min, 2) >= a)
                {
                    count++;
                }
                min++;
            }
            return count;
        }
        static int mirror(List<int> a)
        {
            if (a.Count() == 1)
            {
                return 1;
            }
            if (a.Count() == 0)
            {
                return 0;
            }
            string str = string.Join("", a);
            a.Reverse();
            string str2 = string.Join("", a);
            for (int i = str.Length; i >= 0; i--)
            {
                if (str2.Contains(str.Substring(0, i)))
                {
                    return i;
                }
            }
            return 0;
        }
        static int round(int n)
        {
            // Smaller multiple 
            int a = (n / 50) * 50;

            // Larger multiple 
            int b = a + 50;

            // Return of closest of two 
            return (n - a > b - n) ? b : a;
        }
        static int mirror2(List<int> nums)
        {
            int len = nums.Count();

            int count = 0;

            int max = 0;

            for (int i = 0; i < len; i++)
            {
                count = 0;
                for (int j = len - 1; i + count < len && j > -1; j--)
                {

                    if (nums[i + count] == nums[j])
                    {
                        count++;
                    }

                    else
                    {

                        if (count > 0)
                        {

                            max = Math.Max(count, max);

                            count = 0;

                        }

                    }

                }

                max = Math.Max(count, max);

            }

            return max;
        }
        // Complete the ways function below.
        #region

        static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            scores = scores.Distinct().ToArray();
            List<int> list = new List<int>();
            int wrongnum = 0;
            try
            {
                foreach (int i in alice)
                {
                    if (i > scores[0])
                    {
                        list.Add(1);
                    }
                    else if (i < scores[scores.Count() - 1])
                    {
                        list.Add(scores.Count() + 1);
                    }
                    else
                    {
                        if (i == 29)
                        {

                        }
                        int avg = scores.Count() / 2;
                        list.Add(score(scores, i, 0, scores.Count(), avg));
                    }
                }
            }
            catch (Exception EX)
            {
                Console.WriteLine(wrongnum);
            }
            finally
            {

            }
            return list.ToArray();
        }
        static int score(int[] scores, int alice, int start, int end, int avg)
        {
            int last = 0;

            if (scores[avg] == alice)
            {
                last = avg + 1;
            }
            else if (scores[avg] > alice && scores[avg + 1] <= alice)
            {
                last = avg + 2;
            }
            else if (scores[avg] > alice)
            {
                int avg2 = (avg + end) / 2;
                //if(avg2<avg)
                //{
                last = score(scores, alice, avg, end, avg2);
                //}
            }
            else if (scores[avg] < alice && scores[avg - 1] == alice)
            {
                return avg;
            }
            else if (scores[avg] < alice && scores[avg - 1] > alice)
            {
                return avg + 1;
            }
            else if (scores[avg] < alice)
            {
                int avg2 = (avg + start) / 2;
                last = score(scores, alice, start, avg, avg2);
            }

            return last;
        }

        static int ways(long n, int[] coins)
        {
            List<int> list = coins.ToList();
            int result = 0;
            list.Sort();
            Getcoins(n, list, 0, ref result);
            return result;
        }
        static int sockMerchant(int n, int[] ar)
        {
            int count = 0;
            List<int> nar = ar.ToList<int>();
            nar.Sort();
            for (int i = n - 1; i > 0; i--)
            {

                if (nar[i] == nar[i - 1])
                {
                    count++;
                    nar.RemoveAt(i);
                    nar.RemoveAt(i - 1);
                    i--;
                }

            }
            return count;

        }
        static int countingValleys(int n, string s)
        {
            char[] plan = s.ToCharArray();
            int high = 0;
            int vnum = 0;
            bool isdown = false;
            foreach (char c in plan)
            {
                if (c == 'U')
                {

                    high++;
                }
                else if (c == 'D')
                {
                    high--;
                }
                if (!isdown && high < 0)
                {
                    isdown = true;
                }
                else if (isdown && high == 0)
                {
                    isdown = false;
                    vnum++;
                }

            }
            return vnum;
        }

        static int pageCount(int n, int p)
        {
            /*
             * Write your code here.
             */
            if (n == p)
            {
                return 0;
            }
            if (p % 2 == 0)
            {
                p++;
            }
            int scount = (int)Math.Ceiling(Math.Abs((decimal)(p - n) / 2));
            int mincount = (int)Math.Ceiling(Math.Abs((decimal)(1 - p) / 2));

            return mincount > scount ? scount : mincount;
        }
        static long ways2(long n, int[] coins)
        {

            List<int> list = coins.ToList();
            long[] dp = new long[n + 1];
            dp[0] = 1;
            list.Sort();
            for (int i = 0; i < list.Count(); i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (j >= list[i])
                    {
                        dp[j] = (dp[j] + dp[j - list[i]]);
                    }
                }
            }

            // Getcoins(n, list, 0, ref result);
            return dp[n];
        }
        static void Getcoins(long aimnum, List<int> list, int start, ref int result)
        {
            list.Sum();
            for (int i = start; i < list.Count(); i++)
            {
                if (aimnum - list[i] > 0)
                {
                    Getcoins(aimnum - list[i], list, i, ref result);
                }
                else if (aimnum - list[i] == 0)
                {
                    result++;
                }
                if (aimnum - list[i] < 0)
                {
                    break;
                }
                // tmpresult.RemoveAt(tmpresult.Count() - 1);

            }

        }


        private static bool GetFlag(int num)
        {
            if (num < 1) return false;
            return (num & num - 1) == 0;
        }
        static int[] permutationEquation(int[] p)
        {
            List<int> list = new List<int>();
            foreach (int i in p)
            {
                list.Add(GetY(p, i, false));
            }
            return list.ToArray();
        }
        static int GetY(int[] list, int index, bool islst)
        {

            if (islst)
            {
                return list[index];
            }
            return GetY(list, list[index], true);
        }
        //step01：用delegate定义一个委托
        public delegate int deleFun(int x, int y);
        private static IContainer Container { get; set; }
        static int beautifulDays(int i, int j, int k)
        {

            int n2;
            int count = 0;
            for (int n1 = i; n1 <= j; n1++)
            {

                n2 = Convert.ToInt32(new string(n1.ToString().Reverse().ToArray()));
                if ((n2 - n1) % k == 0)
                {
                    count++;
                }
            }
            return count;
        }
        static int[] circularArrayRotation(int[] a, int k, int[] queries)
        {
            List<int> alist = a.ToList<int>();

            List<int> alist2 = new List<int>();
            for (int i = 0; i < k; i++)
            {
                int tmp = alist[alist.Count() - 1];
                alist.Insert(0, tmp);
                alist.RemoveAt(alist.Count() - 1);
            }
            foreach (int i in queries)
            {
                alist2.Add(alist[i]);
            }
            return alist2.ToArray();
        }
        static int saveThePrisoner(int n, int m, int s)
        {
            if (m > n)
            {
                int gm = (m - (n - s + 1)) % n;//
                if (gm == 0)
                {
                    return m - (n - s + 1);
                }
                else
                {
                    return gm;
                }
            }
            else
            {//3,2,1
                if (n - s + 1 >= m)
                {
                    return s + m - 1;
                }
                else
                {
                    return m - n + s - 1;
                }
            }

            //   return val;


        }
        static int viralAdvertising(int n)
        {
            return Viralloop(1, 5, 0, n);
        }
        static int Viralloop(int day, int likenum, int ljnum, int max)
        {
            int lstnum = 0;
            if (day <= max)
            {
                ljnum += likenum / 2;//累计数
                likenum = likenum / 2 * 3;
                day++;
                lstnum = Viralloop(day, likenum, ljnum, max);
                return lstnum;
            }
            return ljnum;
        }
        #endregion
        static void extraLongFactorials(int n)
        {

        }


        public static List<string> Read()
        {
            FileStream fileStream = new FileStream("E:\\input05.txt", FileMode.Open);
            StreamReader streamReader = null;
            List<string> list = new List<string>();
            byte[] byData = new byte[100];
            char[] charData = new char[1000];
            try
            {
                streamReader = new StreamReader(fileStream, Encoding.Default);
                fileStream.Seek(0, SeekOrigin.Begin);
                string content = streamReader.ReadLine();
                while (content != null)
                {
                    if (!string.IsNullOrEmpty(content))
                    {
                        list.Add(content);
                    }
                    content = streamReader.ReadLine();
                }

            }
            catch
            {
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
            return list;
        }
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 9, 4, 5, 3, 2, 1 };
            List<List<int>> matrix = new List<List<int>>();
            List<string> lines = Read();
            for (int i = 0; i < lines.Count; i++)
            {
                matrix.Add(lines[i].TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
            }
            matrixRotation(matrix, 2);
            //matrix.Add("28 27 26 25".TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
            //matrix.Add("22 9 15 19".TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
            //matrix.Add("16 8 21 13".TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
            //matrix.Add("10 14 20 7".TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
            //matrix.Add("4 3 2 1".TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());

            ////int round2 = round(50);
            ////int sum = mirror(list);
            ////int sum2 = mirror2(list);
            ////string s = appendAndDelete("qwerasdf", "qwerbsdf",6);
            //int s = squares(17, 24);

            //deleFun dFun = delegate(int x, int y) { return x + y; };
            //dFun = (x, y) => { return x + y; };
            ////启用拦截器主要有两个方法：EnableInterfaceInterceptors()，EnableClassInterceptors()
            ////EnableInterfaceInterceptors方法会动态创建一个接口代理
            ////EnableClassInterceptors方法会创建一个目标类的子类代理类，这里需要注意的是只会拦截虚方法，重写方法
            ////注意：需要引用Autofac.Extras.DynamicProxy2才能使用上面两个方法
            #region 启用类代理拦截
            ////创建拦截容器
            //var builder = new ContainerBuilder();

            ////builder.Register(c => new LogInterceptor()).Named<IInterceptor>("log-calls");

            ////类型注入
            ////builder.Register(c => new LogInterceptor());
            ////或者
            //builder.RegisterType<LogInterceptor>();

            ////注册拦截器到容器
            ////builder.RegisterType<LogInterceptor>();
            ////方式一：给类型上加特性Attribute
            //builder.RegisterType<Student>().EnableClassInterceptors();
            //builder.RegisterType<Teacher>().EnableClassInterceptors(); ;
            ////方式二：在注册类型到容器的时候动态注入拦截器(去掉类型上的特性Attribute)
            ////builder.RegisterType<Teacher>().InterceptedBy(typeof(LogInterceptor)).EnableClassInterceptors();
            ////builder.RegisterType<Student>().InterceptedBy(typeof(LogInterceptor)).EnableClassInterceptors();
            ////属性注入
            //builder.Register(c => new Student { Teacher = c.Resolve<Teacher>(), Subject = new Subject(), Name = "张三" });
            //using (var container = builder.Build())
            //{
            //    //从容器获取对象
            //    var Student = container.Resolve<Student>();
            //    Student.Say();
            //    Student.Subject.Show();
            //    Student.Teacher.Show();
            //}
            ////Container = builder.Build();;
            ////创建拦截容器
            //var builder2 = new ContainerBuilder();
            //builder2.RegisterType<StudentTmp>().As<IStudent>();
            //Container = builder2.Build();
            //using (var scope = Container.BeginLifetimeScope())
            //{
            //    var writer = scope.Resolve<IStudent>();
            //    writer.Write("test");
            //}
            ////   int result = saveThePrisoner(3, 7, 3);
            //int[] a = Array.ConvertAll(("1 2 3").Split(' '), aTemp => Convert.ToInt32(aTemp));

            //int[] queries = new int[3] { 0, 1, 2 };

            //int[] result = circularArrayRotation(a, 2, queries);

            // int result = beautifulDays(123 ,456789, 189);
            Console.ReadLine();
            #endregion
        }
    }


}
