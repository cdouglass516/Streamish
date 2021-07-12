import React from "react";
import { Card, CardBody } from "reactstrap";

const SearchForm = ({ link, setIsPreview }) => {
    const handleButtonClick = () => {
        setIsPreview(false);
    }
    return (
        <Card >
            <div>
                <h1>Search For Video</h1>
                <CardBody>
                    <div>
                        
                        
                    </div>
                    <div>
                        <button onClick={() => handleButtonClick()}>Close</button>
                    </div>
                </CardBody>
            </div>
        </Card>

    );
};

export default SearchForm;