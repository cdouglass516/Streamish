const baseUrl = '/api/UserProfile';

export const getAllUsers = () => {
  return fetch(baseUrl)
  .then(function(response) {
    // response.text() returns a new promise that resolves with the full response text
    // when it loads
    return response.json();
  })
  .then(function(data) {
    // ...and here's the content of the remote file
    return data; // {"name": "iliakan", "isAdmin": true}
  });
};


