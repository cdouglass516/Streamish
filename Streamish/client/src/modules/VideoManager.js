

export const getAllVideos = (baseUrl) => {
  return fetch(baseUrl)
    .then((res) => res.json())
};

export const addVideo = (video,baseUrl) => {
  return fetch(baseUrl, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(video),
  });
};
