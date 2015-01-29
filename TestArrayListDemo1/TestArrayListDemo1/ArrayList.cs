using System;


namespace TestArrayListDemo1
{
    public class ArrayList
    {

        //默认容量
        private const int DefaultCapacity = 4;

        //存储对象用的一维数组
        private object[] _item;

        private int _capacity;

        //当前元素个数指示器
        private int _size;

        //给默认的构造函数的一个空数组对象
        private static readonly object[] emptyArray = new object[0];

        //构造方法
        public ArrayList()
        {
            _item = emptyArray;
            _capacity = _item.Length;
            _size = 0;
        }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("capacity", "ArrayList容量不能为负数!");
            }

            _item = new object[capacity];
            _capacity = capacity;
            _size = 0;
        }

        //属性
        // 当前总容量
        public virtual int Capacity
        {
            get { return _capacity; }
            set
            {
                if (value != _item.Length)
                {
                    if (value < this.Count)
                    {
                        throw new ArgumentOutOfRangeException("value", "容量太小了!");
                    }
                    if (value > 0)
                    {
                        object[] destinationArray = new object[value];

                        if (this.Count > 0)
                        {
                            Array.Copy(_item, 0, destinationArray, 0, this.Count);
                        }
                        this._item = destinationArray;
                    }
                    else
                    {
                        this._item = new object[DefaultCapacity];
                        this._capacity = DefaultCapacity;
                    }
                }
                _capacity = value;
            }
        }
        //当前使用个数
        public virtual int Count
        {
            get { return this._size; }
        }

        public virtual object this[int index]
        {
            get
            {
                if (index < 0 || index > this._size)
                {
                    throw new ArgumentOutOfRangeException("index", "索引超出了范围!");
                }
                return this._item[index];
            }
            set
            {
                if (index < 0 || index > this._size)
                {
                    throw new ArgumentOutOfRangeException("index", "索引超出了范围!");
                }
                this._item[index] = value;

            }
        }

        public virtual int Add(object ob)
        {
            //一旦使用个数已经达到了内部数组的固定长度,则先进行扩容
            if (this._size == this._item.Length)
            {
                this.EnsureCapacity(this._size + 1);
            }

            this._item[this._size] = ob;
            return ++this._size;

        }

        public virtual void Insert(int index, object value)
        {
            if (index < 0 || index >= this._size)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出了范围!");
            }
            if (this._size == this._item.Length)
            {
                this.EnsureCapacity(this._size + 1);
            }
            if (index<this._size)
            {
                Array.Copy(this._item,index,this._item,index+1,this._size-index);
            }
            this._item[index] = value;
            this._size++;
        }


        private void EnsureCapacity(int needvalue)
        {
            if (this._item.Length < needvalue)
            {
                //判断内部数组是否为0,为0则先赋一个最小容量值,若不为0则扩成2倍大.
                int num = (this._item.Length == 0) ? DefaultCapacity : (this._item.Length + this._item.Length);
                //扩成2倍大以后再判断是否达到需要的容量 needvalue
                if (num < needvalue)
                {
                    num = needvalue;
                }
                this.Capacity = num;
            }
        }


        public virtual void RemoveAt(int index)
        {
             if (index < 0 || index >= this._size)
            {
                throw new ArgumentOutOfRangeException("index", "索引超出了范围!");
            }

            this._size--;
            if (index<this._size)
            {
                Array.Copy(this._item,index+1,this._item,index,this._size-index);
            }

            this._item[this._size] = null;

        }

        public virtual void TrimToSize()
        {
            this.Capacity = this._size;
        }


    }
}
