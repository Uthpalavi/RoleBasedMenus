import React,{Component} from 'react';
import Navigation from "./Navigation";

export class Login extends Component{

    render(){
        return(
            <div className="mt-5 d-flex justify-content-left">
                <Navigation />
                This is Login page.
            </div>
        )
    }
}