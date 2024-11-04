using System;
using System.Collections.Generic;

public class Comment
{
    public int CommentID { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public int PostID { get; set; }
    public int UserID { get; set; }

    public virtual Post Post { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<Vote> Votes { get; set; }
}
