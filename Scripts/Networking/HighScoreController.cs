/*
Step 1: Create tables
SQL - score.sql
DB - openfire_scores

CREATE TABLE `scores` (
   `id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
   `name` VARCHAR(15) NOT NULL DEFAULT 'anonymous',
   `score` INT(10) UNSIGNED NOT NULL DEFAULT '0'
)
TYPE=MyISAM;

Step 2: Edit the server side scripts

Edit these scripts to reflect your MySQL host server, user, password, database. The table name "scores" should not be edited unless you edited the SQL Query in Step 1. 

PHP - addscore.php

This script will take the name and score HSController.js passes to it and adds them to the MySQL Database.

<?php 
        $db = mysql_connect('mysql_host', 'mysql_user', 'mysql_password') or die('Could not connect: ' . mysql_error()); 
        mysql_select_db('my_database') or die('Could not select database');
 
        // Strings must be escaped to prevent SQL injection attack. 
        $name = mysql_real_escape_string($_GET['name'], $db); 
        $score = mysql_real_escape_string($_GET['score'], $db); 
        $hash = $_GET['hash']; 
 
        $secretKey="mySecretKey"; # Change this value to match the value stored in the client javascript below 

        $real_hash = md5($name . $score . $secretKey); 
        if($real_hash == $hash) { 
            // Send variables for the MySQL database class. 
            $query = "insert into scores values (NULL, '$name', '$score');"; 
            $result = mysql_query($query) or die('Query failed: ' . mysql_error()); 
        } 
?>

addscore.php using PDO

This is the same code/file above, but using better practices in PHP.

Please! This code need to be tested. Tested, confirmed not working. Use snippet above.

<?php
        // Configuration
        $hostname = 'localhot';
        $username = 'yourusername';
        $password = 'yourpassword';
        $database = 'yourdatabase';
 
        $secretKey = "mySecretKey"; // Change this value to match the value stored in the client javascript below 
 
        try {
            $dbh = new PDO('mysql:host='. $hostname .';dbname='. $database, $username, $password);
        } catch(PDOException $e) {
            echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
        }
 
        $realHash = md5($_GET['name'] . $_GET['score'] . $secretKey); 
        if($realHash == $hash) { 
            $sth = $dbh->prepare('INSERT INTO scores VALUES (null, :name, :score)');
            try {
                $sth->execute($_GET);
            } catch(Exception $e) {
                echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() ,'</pre>';
            }
        } 
?>

PHP - display.php

This script will take the top 5 scores from the MySQL Database and put them in a GUIText.

<?php
    // Send variables for the MySQL database class.
    $database = mysql_connect('mysql_host', 'mysql_user', 'mysql_password') or die('Could not connect: ' . mysql_error());
    mysql_select_db('my_database') or die('Could not select database');
 
    $query = "SELECT * FROM `scores` ORDER by `score` DESC LIMIT 5";
    $result = mysql_query($query) or die('Query failed: ' . mysql_error());
 
    $num_results = mysql_num_rows($result);  
 
    for($i = 0; $i < $num_results; $i++)
    {
         $row = mysql_fetch_array($result);
         echo $row['name'] . "\t" . $row['score'] . "\n";
    }
?>

Upload them to wherever you want them on your server.
display.php using PDO

This is the same code/file above, but using PDO.

<?php
    // Configuration
    $hostname = 'localhost';
    $username = 'yourusername';
    $password = 'yourpassword';
    $database = 'yourdatabase';
 
    try {
        $dbh = new PDO('mysql:host='. $hostname .';dbname='. $database, $username, $password);
    } catch(PDOException $e) {
        echo '<h1>An error has occurred.</h1><pre>', $e->getMessage() ,'</pre>';
    }
 
    $sth = $dbh->query('SELECT * FROM scores ORDER BY score DESC LIMIT 5');
    $sth->setFetchMode(PDO::FETCH_ASSOC);
 
    $result = $sth->fetchAll();
 
    if(count($result) > 0) {
        foreach($result as $r) {
            echo $r['name'], "\t", $r['score'], "\n";
        }
    }
?>

XML - crossdomain.xml

Unity requires that websites you want to access via a WWW Request have a cross domain policy.

<?xml version="1.0"?>
<cross-domain-policy>
<allow-access-from domain="*"/>
</cross-domain-policy>

Upload this file to the root of your web server. 


Step 3: The Unity HSController Script

You will attach this script to a GameObject. You need to be able to supply it with a string containing the players name, and a string containing the players score. You also need to edit the URLs in it that point to the correct addscore.php script and the display.php. You will also need to supply it with a GUIText if you want it to get the scores (otherwise you can ignore the getScores() function).

You will also need to include the MD5 script previously posted to this Wiki in your project folder. 

*/


using UnityEngine;
using System.Collections;
 
public class HighScoreController : MonoBehaviour
{
    private string secretKey = "mySecretKey"; // Edit this value and make sure it's the same as the one stored on the server
    public string addScoreURL = "http://localhost/unity_test/addscore.php?"; //be sure to add a ? to your url
    public string highscoreURL = "http://localhost/unity_test/display.php";
 
    void Start()
    {
        StartCoroutine(GetScores());
    }
 
    // remember to use StartCoroutine when calling this function!
    IEnumerator PostScores(string name, int score)
    {
        //This connects to a server side php script that will add the name and score to a MySQL DB.
        // Supply it with a string representing the players name and the players score.
        string hash = MD5Test.Md5Sum(name + score + secretKey);
 
        string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&score=" + score + "&hash=" + hash;
 
        // Post the URL to the site and create a download object to get the result.
        WWW hs_post = new WWW(post_url);
        yield return hs_post; // Wait until the download is done
 
        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
    }
 
    // Get the scores from the MySQL DB to display in a GUIText.
    // remember to use StartCoroutine when calling this function!
    IEnumerator GetScores()
    {
        gameObject.guiText.text = "Loading Scores";
        WWW hs_get = new WWW(highscoreURL);
        yield return hs_get;
 
        if (hs_get.error != null)
        {
            print("There was an error getting the high score: " + hs_get.error);
        }
        else
        {
            gameObject.guiText.text = hs_get.text; // this is a GUIText that will display the scores in game.
        }
    }
 
}