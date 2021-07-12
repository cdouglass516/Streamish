/* eslint-disable jsx-a11y/anchor-is-valid */
import React from "react"
import "bootstrap/dist/css/bootstrap.min.css";

export const NavBar = (props) => {
    const handleMarkerLink = (link) => {
        props.setIsPreview(true);
        props.setLink(link);
    }
    return (
        <div className=" nav-color ">
            <nav className="navbar flex-md-nowrap p-0 shadow">

                <ul className="nav nav-pills nav-fill nb_width">
                    <li className="nav-item">

                    </li>
                    <li className="nav-item ">
                        <a className="nav-link navbar_link " href="#" alt="Nashville Venues" onClick={() => handleMarkerLink('search')}>Search Videos</a>
                    </li>
                    <li className="nav-item ">
                        <a className="nav-link navbar_link " href="#" alt="Get by date" onClick={() => handleMarkerLink('date')}>Search By Date</a>
                    </li>
                </ul>
            </nav>
        </div>
    )
}