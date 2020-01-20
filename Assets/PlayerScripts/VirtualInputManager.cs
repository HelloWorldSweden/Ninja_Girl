using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NinjaGirl
{
    public class VirtualInputManager : Singltone<VirtualInputManager>
    {
        public bool moveRight;
        public bool moveLeft;
        public bool jump;
        public bool attacking;
        public bool moveUp;
        public bool moveDown;
    }
}

