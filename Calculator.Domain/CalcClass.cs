using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Domain
{
    public class Complecs : Icalculaible<Complecs>
    {
        public Complecs(string stroka = "0+j0")
        {
            Rewrite(stroka);
        }

        private int a;
        public string A
        {
            get { return a.ToString(); }
            set
            {
                try
                {
                    a = int.Parse(value);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong enter");
                }
            }
        }
        private int b;
        public string B
        {
            get { return b.ToString(); }
            set
            {
                try
                {
                    b = int.Parse(value);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong enter");
                }
            }
        }

        public void Rewrite(string stroka)
        {
            string chisloA, chisloB, Vremenoe;
            chisloA = string.Empty;
            chisloB = string.Empty;
            Vremenoe = string.Empty;
            for (int i = 0; i < stroka.Length; i++)
            {
                if ((stroka[i] == '+' || stroka[i] == '-') && i != 0)
                {
                    chisloA = Vremenoe;
                    Vremenoe = string.Empty + stroka[i];
                }
                else if (stroka[i] == 'j')
                {
                    continue;
                }
                else
                {
                   Vremenoe += stroka[i];
                }
            }
            chisloB = Vremenoe;
            A = chisloA;
            B = chisloB;
        }
        public override string ToString()
        {
            if (b < 0)
                return string.Format("{0}{1}j", A, B);
            else
                return string.Format("{0}+{1}j", A, B);
        }
        public Complecs Add(Complecs addValue)
        {
            this.a += addValue.a;
            this.b += addValue.b;
            return this;
        }
        public Complecs Remove(Complecs remove)
        {
            this.a -= remove.a;
            this.b -= remove.b;
            return this;
        }
        public Complecs Divide(Complecs div)
        {
            int c = this.a;
            int d = div.a;
            this.a = Convert.ToInt32((a*div.a + b*div.b)/(Math.Pow(div.a,2) + Math.Pow(div.b,2)));
                this.b = Convert.ToInt32(((b*d-c*div.b)/(Math.Pow(d,2) + Math.Pow(div.b,2))));
                return this;
        }
        public Complecs Multiply(Complecs multi)
        {
            this.a = a * multi.a;
            this.b = b * multi.b;
            return this;
        }
        public Complecs Clear(Complecs clearValue)
        {
            this.a = clearValue.a*0;
            this.b = clearValue.b*0;
            return this;
        }
        public Complecs Sqrt(Complecs sqrt)
        {
            int r = Convert.ToInt32(Math.Sqrt(Math.Sqrt(Math.Pow(sqrt.a, 2) + Math.Pow(sqrt.b, 2))));
            try
            {
                this.a = r * (a / r + b / r);
            }
            catch (Exception e)
            {
                throw e;
            }
            
            return this;
        }
        public Complecs Modul(Complecs mod)
        {
            this.a = Convert.ToInt32(Math.Sqrt(Math.Pow(mod.a, 2) + Math.Pow(mod.b, 2)));
            this.b = 0;
            return this;
        }
    }

    public interface Icalculaible<T>
    {
        T Add(T add);
        T Remove(T remove);
        T Divide(T div);
        T Multiply(T multi);
        T Clear(T clearValue);
        string ToString();
    }

    public class Real<T> : Icalculaible<Real<T>> where T: struct
    {
        public T valuereal { get; set; }
        public Real(T intconstr)
        {
            this.valuereal = intconstr;
        }
        public override string ToString()
        {
            return string.Format("{0}", valuereal);
        }
        public Real<T> Add(Real<T> add)
        {
            dynamic a = this.valuereal, b = add.valuereal;
            a += b;
            this.valuereal = (T)a;
            return this;
        }
        public Real<T> Remove(Real<T> remove)
        {
            dynamic a = this.valuereal, b = remove.valuereal;
            a -= b;
            this.valuereal = (T)a;
            return this;
        }
        public Real<T> Divide(Real<T> div)
        {
            dynamic a = this.valuereal, b = div.valuereal;
            a /= b;
            this.valuereal = (T)a;
            return this;
        }
        public Real<T> Multiply(Real<T> multi)
        {
            dynamic a = this.valuereal, b = multi.valuereal;
            a *= b;
            this.valuereal = (T)a;
            return this;
        }
        public Real<T> Clear(Real<T> clearValue)
        {
            dynamic a = 0;
            this.valuereal = (T)a;
            return this;
        }
        public Real<T> Sqrt(Real<T> sqrt)
        {
            dynamic a = this.valuereal;
            try
            {
                a = Math.Sqrt(a);
            }
            catch (Exception e)
            {
                throw e;
            }
            this.valuereal = (T)a;
            return this;
        }
        public Real<T> Modul(Real<T> mod)
        {
            dynamic a = this.valuereal;
            if(a!= 0)
            a = Math.Abs(a);
            else
            {
                a = 0;
            }
            this.valuereal = (T) a;
            return this;
        }
    }
}
