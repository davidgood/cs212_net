namespace CS212
{
    public class OnlineStudent(string name, string id) : Student(name, id, StudentType.Online)
    {
        private int _forumPosts;
        private int _videoLecturesCompleted;

        public void IncrementForumPosts()
        {
            _forumPosts++;
        }

        public void CompleteVideoLecture()
        {
            _videoLecturesCompleted++;
        }

        public override void SimulateApiPost()
        {
            base.SimulateApiPost();
            Console.WriteLine($"Forum Posts: {_forumPosts}");
            Console.WriteLine($"Video Lectures Completed: {_videoLecturesCompleted}");
        }
    }
}