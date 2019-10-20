using System;
using System.Collections.Generic;
namespace April2018
{
    public class MyHashMap<TKey, TValue>
    {
        // List of 
        LinkedList<DataItem>[] arr = new LinkedList<DataItem>[100];

        public class DataItem
        {
            public TKey key;
            public TValue val;
            public DataItem(TKey k, TValue v)
            {
                this.key = k;
                this.val = v;
            }
        }
        
        public MyHashMap()
        {
        }

        public void Add(TKey key, TValue val)
        {
            int hc = GetHash(key);

            LinkedList<DataItem> lst = arr[hc];
			DataItem d = new DataItem(key, val);
            if(lst == null)
            {
                lst = new LinkedList<DataItem>();
            }
            else
            {
				LinkedListNode<DataItem> cur = lst.First;
				while (cur != null)
				{
					DataItem dt = cur.Value;
					if (Compare(dt.key, key))
					{
						throw new Exception("Key Already Exists");
					}
					cur = cur.Next;
				}
            }       

            lst.AddLast(d);
            arr[hc] = lst;
        }

		public bool Compare<T>(T x, T y)
		{
			return EqualityComparer<T>.Default.Equals(x, y);
		}

        public void TryGetValue(TKey key, out TValue v)
        {
            int hc = GetHash(key);
            LinkedList<DataItem> lst = arr[hc];
           
            TValue tv = default(TValue);
            if(lst != null)
            {
				LinkedListNode<DataItem> cur = lst.First;
				while (cur != null)
				{
					if (Compare(cur.Value.key, key))
					{
						tv = cur.Value.val;
						break;
					}
					cur = cur.Next;
				}
            }			
            v = tv;
        }

        public TValue GetValue(TKey k)
        {
            TValue v = default(TValue);
            TryGetValue(k, out v);
            return v;
        }

        private int GetHash(TKey k)
        {
            return Math.Abs(k.GetHashCode() % 100);
        }
    }
}
