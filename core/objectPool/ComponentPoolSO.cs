//using System.Collections;
using UnityEngine;

    //该脚本将池子安排给一个场景中的父级对象
    //用于整理子物品
    public abstract class ComponentPoolSO<T> : PoolSO<T> where T : Component
    {
        private Transform _poolRoot;
        private Transform PoolRoot
        {
            get
            {
                if (_poolRoot == null)
                {
                    _poolRoot = new GameObject(name).transform;
                    _poolRoot.SetParent(_parent);
                }
                return _poolRoot;
            }
        }

        private Transform _parent;



        //pool在场景中的父级对象
        //可以考虑分配给一个DontDestroyOnLoad对象
        public void SetParent(Transform t)
        {
            _parent = t;
            PoolRoot.SetParent(_parent);
        }

        public override T Request()
        {
            T member = base.Request();
            member.gameObject.SetActive(true);
            return member;
        }

        public override void Return(T member)
        {
            //模仿destroy 下一帧执行return
            //StartCoroutine(returnWait(member));//然而需要继承mono
            member.transform.SetParent(PoolRoot.transform);
            member.gameObject.SetActive(false);
            base.Return(member);
        }
        //IEnumerator returnWait(T member) {
          //  yield return null;
          //  member.transform.SetParent(PoolRoot.transform);
          //  member.gameObject.SetActive(false);
          //  base.Return(member);
        //}

        protected override T Create()
        {
            T newMember = base.Create();
            newMember.transform.SetParent(PoolRoot.transform);
            newMember.gameObject.SetActive(false);
            return newMember;
        }

        public override void OnDisable()
        {
            base.OnDisable();
            if (_poolRoot != null)
            {
#if UNITY_EDITOR
                DestroyImmediate(_poolRoot.gameObject);
#else
				Destroy(_poolRoot.gameObject);
#endif
            }
        }
    }