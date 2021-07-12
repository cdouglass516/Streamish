import React, { useEffect, useState } from "react";
import Video from './Video';
import { getAllVideos } from "../modules/VideoManager";

const VideoList = ({baseUrl}) => {
  const [videos, setVideos] = useState([]);

  const getVideos = () => {
    getAllVideos(baseUrl).then(videos => setVideos(videos));
  };

  useEffect(() => {
    getVideos();
  }, []);

  return (
    <div className="container">
      <div className="row justify-content-center">
        {videos.map((video) => (
          <Video video={video} key={video.id} />
        ))}
      </div>
    </div>
  );
};

export default VideoList;
