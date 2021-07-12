import React from "react";

const Comment = ({ comment}) => {

    return (

                <p>{comment.userProfile.name} says:{comment.message}</p>

    );
};

export default Comment;
