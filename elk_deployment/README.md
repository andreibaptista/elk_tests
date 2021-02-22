This guide will install 3 ElasticSearch nodes (1 master, 1 data, 1 ingest), 1 Logstash node and 1 Kibana

To install ELASTICSEARCH, use Helm with the following command:

- helm install dev.es.master elastic/elasticsearch -f values_dev_es_master.yaml -n elk
- helm install dev.es.data elastic/elasticsearch -f values_dev_es_data.yaml -n elk
- helm install dev.es.ingest elastic/elasticsearch -f values_dev_es_ingest.yaml -n elk

- Helm uninstall dev.es.master
- Helm uninstall dev.es.data
- Helm uninstall dev.es.ingest

Minikube requirements:

- minikube addons enable default-storageclass
- minikube addons enable storage-provisioner


For more values examples:

https://github.com/elastic/helm-charts/blob/master/elasticsearch/values.yaml

--------------------

To install KIBANA, use Helm with the following command:
- helm install dev-k elastic/kibana -f values_dev_k.yaml -n elk
- helm uninstall dev-k

--------------------

To install LOGSTASH, use Helm with the following command:
- helm install dev-ls elastic/logstash -f values_dev_ls.yaml -n elk
- helm uninstall dev-ls

--------------------

If this error shows up:

[illegal_argument_exception] Trying to retrieve too many docvalue_fields. Must be less than or equal to: [100] but was [137]. This limit can be set by changing the [index.max_docvalue_fields_search] index level setting.


Do the following:

kubectl port-forward svc/elasticsearch-master 9200

PUT http://localhost:9200/<INDEX_NAME>/_settings

{
    "index" : {
        "max_docvalue_fields_search" : 200
    }
}
