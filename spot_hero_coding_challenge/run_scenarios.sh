#!/bin/bash

#Must run in directory of executable.

echo " "
echo "------------------------------------"
echo "Loading rates_example.json"
echo "------------------------------------"
echo " "

echo "Running Scenario 1"
java -jar spot_hero_coding_challenge.jar "rates_example.json" "2015-07-01T07:00:00Z" "2015-07-01T12:00:00Z"

echo " "
echo "Running Scenario 2"
java -jar spot_hero_coding_challenge.jar "rates_example.json" "2015-07-04T07:00:00Z" "2015-07-04T12:00:00Z"

echo " "
echo "Running Scenario 3"
java -jar spot_hero_coding_challenge.jar "rates_example.json" "2015-07-04T07:00:00Z" "2015-07-04T20:00:00Z"

echo " "
echo "Running Scenario 4 - Two different days."
java -jar spot_hero_coding_challenge.jar "rates_example.json" "2015-07-04T07:00:00Z" "2015-07-05T20:00:00Z"

echo " "
echo "Running Scenario 5 - Same Weekday, a week apart."
java -jar spot_hero_coding_challenge.jar "rates_example.json" "2015-07-04T10:00:00Z" "2015-07-11T19:00:00Z"

echo " "
echo "Running Scenario 6 - Start time after the end time."
java -jar spot_hero_coding_challenge.jar "rates_example.json" "2015-07-04T19:00:00Z" "2015-07-04T18:00:00Z"

echo " "
echo "------------------------------------"
echo "Loading rates_example2.json"
echo "------------------------------------"
echo " "

echo "Running Scenario 1"
java -jar spot_hero_coding_challenge.jar "rates_example2.json" "2015-07-01T07:00:00Z" "2015-07-01T12:00:00Z"

echo " "
echo "Running Scenario 2"
java -jar spot_hero_coding_challenge.jar "rates_example2.json" "2015-07-04T07:00:00Z" "2015-07-04T12:00:00Z"

echo " "
echo "Running Scenario 3"
java -jar spot_hero_coding_challenge.jar "rates_example2.json" "2015-07-04T07:00:00Z" "2015-07-04T20:00:00Z"

echo " "
echo "Running Scenario 4 - Two different days."
java -jar spot_hero_coding_challenge.jar "rates_example2.json" "2015-07-04T07:00:00Z" "2015-07-05T20:00:00Z"

echo " "
echo "Running Scenario 5 - Same Weekday, a week apart."
java -jar spot_hero_coding_challenge.jar "rates_example2.json" "2015-07-04T10:00:00Z" "2015-07-11T20:00:00Z"

echo " "
echo "Running Scenario 6 - Start time after the end time."
java -jar spot_hero_coding_challenge.jar "rates_example2.json" "2015-07-04T19:00:00Z" "2015-07-04T18:00:00Z"

echo " "
echo "Running Scenario 7 - Mon 9 to 12"
java -jar spot_hero_coding_challenge.jar "rates_example2.json" "2015-07-06T09:00:00Z" "2015-07-06T20:59:00Z"

echo " "
echo "Running Scenario 8 - Mon 1 to 5"
java -jar spot_hero_coding_challenge.jar "rates_example2.json" "2015-07-06T01:00:00Z" "2015-07-06T04:59:00Z"

echo " "
echo "Running Scenario 9 - Wed 1 to 5"
java -jar spot_hero_coding_challenge.jar "rates_example2.json" "2015-07-01T01:00:00Z" "2015-07-01T04:59:00Z"

echo " "
echo "Running Scenario 10 - Wed 6 to 6"
java -jar spot_hero_coding_challenge.jar "rates_example2.json" "2015-07-01T06:00:00Z" "2015-07-01T17:59:00Z"

echo " "
echo "Running Scenario 11 - Sun 1 to 7"
java -jar spot_hero_coding_challenge.jar "rates_example2.json" "2015-07-05T01:00:00Z" "2015-07-05T06:59:00Z"

echo " "
echo "Running Scenario 12 - Sun 9 to 9"
java -jar spot_hero_coding_challenge.jar "rates_example2.json" "2015-07-05T09:00:00Z" "2015-07-05T20:59:00Z"

echo " "
echo "Running Scenario 13 - Fri 9 to 9"
java -jar spot_hero_coding_challenge.jar "rates_example2.json" "2015-07-03T09:00:00Z" "2015-07-03T20:59:00Z"

echo " "
echo "Finished, have a nice day."
echo " "
echo " "