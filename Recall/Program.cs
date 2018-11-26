using System;
using System.Collections.Generic;

namespace Recall
{
    public abstract class Component
    {
        protected string _name;

        protected Component(string name)
        {
            this._name = name;
        }

        public virtual void Add(Component component) { }

        public virtual void Remove(Component component) { }

        public virtual void Print()
        {
            Console.WriteLine(_name);
        }

    }

    public class File : Component
    {
        public File(string name) : base(name) { }
    }

    public class Directory : Component
    {
        private List<Component> _components = new List<Component>();

        public Directory(string name) : base(name) { }

        public override void Add(Component component)
        {
            _components.Add(component);
        }

        public override void Remove(Component component)
        {
            _components.Remove(component);
        }

        public override void Print()
        {
            base.Print();

            foreach (var item in _components)
            {
                item.Print();
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Component root = new Directory("D");
            Component gamesFolder = new Directory("Games");
            Component picsFolder = new Directory("Pics");

            Component tetrisEXE = new File("Tetris.exe");

            gamesFolder.Add(tetrisEXE);

            root.Add(gamesFolder);
            root.Add(picsFolder);

            root.Print();
        }
    }
}
