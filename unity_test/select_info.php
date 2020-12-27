<?php

    include "connect.php";

    $infoName = $_GET["infoName"];

    $query = "SELECT `description` FROM `info` WHERE `name` = '$infoName'";
    $result =  $db->query($query);

    echo $result->fetch_array()[0];

?>