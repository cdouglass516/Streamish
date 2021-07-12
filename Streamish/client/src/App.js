import React from "react";
import "./App.css";
import VideoList from "./components/VideoList";
import {NavBar} from "./components/NavBar"
import SearchForm from "./components/SearchForm";

function App() {
  const [link, setLink] = React.useState("");
  const [isPreview, setIsPreview] = React.useState(false);
  const [baseUrl, setBaseUrl] = React.useState('/api/Video/search?q=c%2B%2B&sortDesc=false');
  return (
    <div className="App">
      <NavBar setIsPreview={setIsPreview} setLink={setLink}/>
      { isPreview && <SearchForm link={link} setIsPreview={setIsPreview} /> }
      <VideoList baseUrl={baseUrl} />
    </div>
  );
}

export default App;