<?php
    
    include "connect.php";

    $email = $_GET['email'];
    $password = $_GET['password'];
    //$hash = $_GET['hash'];
    
    $query = "insert into accounts values (NULL, '$email', '$password', 0);";
    $result = $database->query($query);
    
?>