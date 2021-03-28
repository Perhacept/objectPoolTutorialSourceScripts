using System.Collections.Generic;
using UnityEngine;

    public abstract class PoolSO<T> : ScriptableObject, IPool<T>
    {
        //protected readonly Stack<T> Available = new Stack<T>();//栈(Stack)/队列(Queue)比list性能消耗低
        protected readonly Queue<T> Available = new Queue<T>();//队列
        public abstract IFactory<T> Factory { get; set; }
        protected bool HasBeenPrewarmed { get; set; }

        protected virtual T Create()
        {
            return Factory.Create();
        }


        //预热池子
        //此方法可以随时调用，但池子的生命周期中只能调用一次（一个生命周期调用一次）
        //num是预热数
        public virtual void Prewarm(int num)
        {
            if (HasBeenPrewarmed)
            {
                Debug.LogWarning($"Pool {name} has already been prewarmed.");
                return;
            }
            for (int i = 0; i < num; i++)
            {
                //Available.Push(Create());
                Available.Enqueue(Create());
            }
            HasBeenPrewarmed = true;
        }


        //请求
        public virtual T Request()
        {
            //return Available.Count > 0 ? Available.Pop() : Create();//pop或创建
            return Available.Count > 0 ? Available.Dequeue() : Create();//Dequeue或创建
        }

        //返回一个IEnumerator对象(可枚举对象)
        public virtual IEnumerable<T> Request(int num = 1)
        {
            List<T> members = new List<T>(num);
            for (int i = 0; i < num; i++)
            {
                members.Add(Request());
            }
            return members;
        }


        //归还
        public virtual void Return(T member)
        {
            //Available.Push(member);
            Available.Enqueue(member);
        }


        //归还一个可枚举对象(一系列物品)
        public virtual void Return(IEnumerable<T> members)
        {
            foreach (T member in members)
            {
                Return(member);
            }
        }

        public virtual void OnDisable()
        {
            Available.Clear();
            HasBeenPrewarmed = false;
        }
    }
