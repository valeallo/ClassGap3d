using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator 
{ //everything inside a static class it must be static
    
    
        private static Player player;
        public static Player GetPlayer() { return player;  } //accesser and mutator not getter and setter 
        public static void SetPlayer(Player p) { player = p;  }
    
}
//public private and protected protected it can be access only by the children 
//private only this class prublic by every class and 