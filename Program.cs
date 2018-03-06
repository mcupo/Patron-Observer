using System;

using System.Collections.Generic;

namespace DoFactory.GangOfFour.Observer.Structural

{

    class MainApp

    {

        static void Main()

        {

            ConcreteSubject s = new ConcreteSubject();

            s.Attach(new ConcreteObserver(s, "X"));

            s.Attach(new ConcreteObserver(s, "Y"));

            s.Attach(new ConcreteObserver(s, "Z"));

            //Cambia el estado y notifica

            s.SubjectState = "ABC";

            s.Notify();

            Console.ReadKey();

        }

    }

    //La clase Sujeto

    abstract class Subject

    {

        private List<Observer> _observers = new List<Observer>();

        public void Attach(Observer observer)

        {

            _observers.Add(observer);

        }

        public void Detach(Observer observer)

        {

            _observers.Remove(observer);

        }

        public void Notify()

        {

            foreach (Observer o in _observers)

            {

                o.Update();

            }

        }

    }

    //La clase SujetoConcreto

    class ConcreteSubject : Subject

    {

        private string _subjectState;

        public string SubjectState

        {

            get { return _subjectState; }

            set { _subjectState = value; }

        }

    }

    //La clase Observer

    abstract class Observer

    {

        public abstract void Update();

    }

    //La clase ObservadorConcreto

    class ConcreteObserver : Observer

    {

        private string _name;

        private string _observerState;

        private ConcreteSubject _subject;

        // Constructor

        public ConcreteObserver(ConcreteSubject subject, string name)

        {

            this._subject = subject;

            this._name = name;

        }

        public override void Update()

        {

            _observerState = _subject.SubjectState;

            Console.WriteLine("El nuevo estado del observer {0} es {1}", _name, _observerState);

        }

        public ConcreteSubject Subject

        {

            get { return _subject; }

            set { _subject = value; }

        }

    }

}
