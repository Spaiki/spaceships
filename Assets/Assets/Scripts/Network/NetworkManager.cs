using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkManager : MonoBehaviour {
	private GroupIDProvider objectIDProvider = new GroupIDProvider(1000);
	
	public int AllocateID(){
		return objectIDProvider.Allocate();
	}

	public void DeallocateID(int id){
		objectIDProvider.Deallocate(id);
	}
	
	private class GroupIDProvider {
		private Stack<int> deallocatedIDs = new Stack<int>();
		private int current_maxID;
		
		public GroupIDProvider(int startID){
			current_maxID = startID;
		}
		
		public int Allocate(){
			if(deallocatedIDs.Count>0){
				return deallocatedIDs.Pop();
			} else {
				current_maxID++;
				return current_maxID;
			}
		}
		
		public void Deallocate(int id){
			deallocatedIDs.Push(id);
		}
	}
}
