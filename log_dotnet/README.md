.netcore 3.1 API it will log on console like crazy after calling the only GET method

For tests purpose only.

How to use:
- kubectl apply -f core-log.yaml

Make a HTTP GET request to: <INGRESS_IP>/log

It will log this:

[19:37:59 DBG] LogDebug

[19:37:59 FTL] LogCritical

[19:37:59 ERR] LogError

[19:37:59 INF] LogInformation

[19:37:59 VRB] LogTrace

[19:37:59 WRN] LogWarning


To stop logging,  just kill the pod with the following command:
- kubectl delete pods -l app=core-log --force --grace-period=0 -n core-log
