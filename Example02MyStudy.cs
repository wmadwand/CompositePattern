using System;
using System.Collections.Generic;

namespace Composite
{
    public abstract class Component
    {
        protected string _name;

        protected Component(string name)
        {
            _name = name;
        }

        public virtual void Add(Component component) { }

        public virtual void Remove(Component component) { }

        public virtual void Print()
        {
            Console.WriteLine(_name);
        }
    }

    public class Directory : Component
    {
        private List<Component> _components = new List<Component>();

        public Directory(string name) : base(name)
        {
            _name = name;
        }

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

    public class File : Component
    {
        public File(string name) : base(name)
        {
        }
    }

    public class Main
    {
        public void Start()
        {
            Component fileSystem = new Directory("File sys");
            Component discD = new Directory("DiscD");

            Component picsFolder = new Directory("picsFolder");

            Component pic01 = new File("pic01.jpg");
            Component pic02 = new File("pic02.jpg");
            Component pic03 = new File("pic03.jpg");

            picsFolder.Add(pic01);
            picsFolder.Add(pic02);
            picsFolder.Add(pic03);

            discD.Add(picsFolder);

            fileSystem.Add(discD);

            picsFolder.Remove(pic01);

            fileSystem.Print();
        }
    }
}