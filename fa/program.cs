using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fans;

namespace fans
{

    public class State
    {
        public string name;
        public Dictionary<char, State> Transit;
        public bool isFinal;
    }


    public class FA1
    {


        public static State q0state;
        public State q1state;
        public State q2state;
        public State q3state;
        public State q4state;


        public FA1()
        {
            q0state = new State()
            {
                name = "q0", Transit = new Dictionary<char, State>(), isFinal = false
            };
            q1state = new State()
            {
                name = "q1", Transit = new Dictionary<char, State>(), isFinal = false
            };
            q2state = new State()
            {
                name = "q2", Transit = new Dictionary<char, State>(), isFinal = true
            };
            q3state = new State()
            {
                name = "q3", Transit = new Dictionary<char, State>(), isFinal = false
            };
            q4state = new State()
            {
                name = "q4", Transit = new Dictionary<char, State>(), isFinal = false
            };

            q0state.Transit.Add('0', q2state);
            q0state.Transit.Add('1', q3state);
            q1state.Transit.Add('0', q4state);
            q1state.Transit.Add('1', q2state);
            q2state.Transit.Add('0', q4state);
            q2state.Transit.Add('1', q2state);
            q3state.Transit.Add('0', q2state);
            q3state.Transit.Add('1', q3state);
            q4state.Transit.Add('0', q4state);
            q4state.Transit.Add('1', q4state);

        }

        public bool? Run(IEnumerable<char> s)
        {

            State cur = q0state;
            foreach (var c in s)
            {
                cur = cur.Transit[c]; // меняем состояние на то, в которое у нас переход
                if (cur == null) // если его нет, возвращаем признак ошибки
                    return null;
            }

            return cur.isFinal;
        }
    }


    public class FA2
    {
        public static State q0state;
        public State q1state;
        public State q2state;
        public State q3state;

        public FA2()
        {
            q0state = new State()
            {
                name = "q0", Transit = new Dictionary<char, State>(), isFinal = false
            };
            q1state = new State()
            {
                name = "q1", Transit = new Dictionary<char, State>(), isFinal = false
            };
            q2state = new State()
            {
                name = "q2", Transit = new Dictionary<char, State>(), isFinal = false
            };
            q3state = new State()
            {
                name = "q3", Transit = new Dictionary<char, State>(), isFinal = true
            };
            q0state.Transit.Add('0', q2state);
            q0state.Transit.Add('1', q1state);
            q1state.Transit.Add('0', q3state);
            q1state.Transit.Add('1', q0state);
            q2state.Transit.Add('0', q0state);
            q2state.Transit.Add('1', q3state);
            q3state.Transit.Add('0', q1state);
            q3state.Transit.Add('1', q2state);
        }
        public bool? Run(IEnumerable<char> s)
        {   State cur = q0state;
            foreach (var c in s)
            {
                cur = cur.Transit[c]; // меняем состояние на то, в которое у нас переход
                if (cur == null) // если его нет, возвращаем признак ошибки
                    return null;
            }

            return cur.isFinal;}
    }

    public class FA3
    {
        public static State q0state;
        public State q1state;
        public State q2state;

        public FA3()
        {
            q0state = new State()
            {
                name = "q0", Transit = new Dictionary<char, State>(), isFinal = false
            };
            q1state = new State()
            {
                name = "q1", Transit = new Dictionary<char, State>(), isFinal = false
            };
            q2state = new State()
            {
                name = "q2", Transit = new Dictionary<char, State>(), isFinal = true
            };
            q0state.Transit.Add('0', q0state);
            q0state.Transit.Add('1', q1state);
            q1state.Transit.Add('0', q0state);
            q1state.Transit.Add('1', q2state);
            q2state.Transit.Add('0', q2state);
            q2state.Transit.Add('1', q2state);
        }

        public bool? Run(IEnumerable<char> s)
        {
            State cur = q0state;
            foreach (var c in s)
            {
                cur = cur.Transit[c]; // меняем состояние на то, в которое у нас переход
                if (cur == null) // если его нет, возвращаем признак ошибки
                    return null;
            }

            return cur.isFinal;}
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "0101";
            FA1 faa1 = new FA1();
            bool? result1 = faa1.Run(s);
            Console.WriteLine(result1);
            FA2 faa2 = new FA2();
            bool? result2 = faa2.Run(s);
            Console.WriteLine(result2);
            FA3 faa3 = new FA3();
            bool? result3 = faa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}    
    
    