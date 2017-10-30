<?php

require_once('lib/nusoap.php');

function  add($a,$b){
 return $a + $b;
}

function div($a,$b){
        return $a / $b;
}

$server = new soap_server();

$server->configureWSDL('Jemix WS ','urn:http://jemiaymen.com');


$server->register("add",
                // param
                array('a'=>'xsd:int','b'=>'xsd:int'), 
                // return
                array('return'=>'xsd:int'),
                // namespace
                "http://jemiaymen.com",
                // soapaction
                false,
                // style
                'rpc',
                // use
                'encoded',
                // description
                'A simple add web method');
$server->register("div",
                // param
                array('a'=>'xsd:int','b'=>'xsd:int'), 
                // return
                array('return'=>'xsd:int'),
                // namespace
                "http://jemiaymen.com",
                // soapaction
                false,
                // style
                'rpc',
                // use
                'encoded',
                // description
                'A simple div web method');

$HTTP_RAW_POST_DATA = isset($HTTP_RAW_POST_DATA) ? $HTTP_RAW_POST_DATA : '';
$server->service($HTTP_RAW_POST_DATA);
	
?>