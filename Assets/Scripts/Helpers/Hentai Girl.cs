using System.Collections.Generic;

namespace Helpers
{
    [System.Serializable]
    public class HentaiGirl 
    {
        private int totalLevels;
        private int completedLevels;
        private string path;
        private List<string> activeLayers;
    
        public int GetTotalLevels(){
            return totalLevels;
        }
    
        public int GetCompletedLevels(){
            return completedLevels;
        }

        public void SetTotalLevels(int totalLevels){
            this.totalLevels = totalLevels;
        }
    
        public void SetCompletedLevels(int completedLevels){
            this.completedLevels = completedLevels;
        }
    
        public void SetPath(string path){
            this.path = path;
        }
    
        public string GetPath(){
            return path;
        }

        public bool IsCompleted()
        {
            return totalLevels == completedLevels;
        }
    
        public bool CompleteLevel(int level)
        {
            // повертаю тру якшо рівнень зберігся, фолс якщо він вже був пройдений
            if (completedLevels < level)
            {
                completedLevels++;
                return true;
            }

            return false;
        }

        public void SetLayers(List<string> layers)
        {
            activeLayers = layers;
        }

        public List<string> GetLayers()
        {
            return activeLayers;
        }
    
        public HentaiGirl(int totalLevels, int completedLevels, string path){
            this.totalLevels = totalLevels;
            this.completedLevels = completedLevels;
            this.path = path;
            this.activeLayers = new List<string>();
        }
    

        public HentaiGirl(int completedLevels, string path){
            totalLevels = 3;
            this.completedLevels = completedLevels;
            this.path = path;
            this.activeLayers = new List<string>();
        }
    }
}
