Filebeat is meant to be installled in a different namespace: beat

To install FILEBEAT, use Helm with the following command:

- helm install dev.fb elastic/filebeat -f ./values_dev_fb.yaml -n beat


#To install METRICBEAT, use Helm with the following command:

#- helm install metricbeat elastic/metricbeat -f ./mb_values.yaml -n elk
