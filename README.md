# Elasticsearch_Client

## راهنمای راه‌اندازی Elasticsearch و Kibana با Docker

### مقدمه

Elasticsearch یک موتور جستجوی و تجزیه و تحلیل متن و ساختار نیافته قدرتمند است که به شما امکان می‌دهد داده‌های خود را به صورت بلادرنگ جستجو، تجزیه و تحلیل و مشاهده کنید. Kibana یک رابط کاربری وب برای Elasticsearch است که به شما امکان می‌دهد داشبوردهای تعاملی بسازید، داده‌ها را تجسم کنید و الگوها را در داده‌های خود کشف کنید.

این راهنما به شما نشان می‌دهد که چگونه Elasticsearch و Kibana را با استفاده از Docker در یک محیط محلی راه‌اندازی کنید.

### پیش‌نیازها

* Docker نصب شده باشد
* دانش اولیه خط فرمان

### مراحل

1. **یک پوشه برای پروژه خود ایجاد کنید:**

```bash
mkdir elasticsearch-kibana
cd elasticsearch-kibana
```

2. **فایل `docker-compose.yml` را ایجاد کنید:**

```yaml
version: "3.8"

services:
  elasticsearch:
    image: docker.elastic.co/elasticsearch/elasticsearch:7.17.1
    container_name: elasticsearch
    environment:
      - ELASTIC_PASSWORD=password
      - DISCOVERY_TYPE=single-node
    ports:
      - "9200:9200"
      - "9600:9600"
  kibana:
    image: docker.elastic.co/kibana/kibana:7.17.1
    container_name: kibana
    depends_on:
      - elasticsearch
    ports:
      - "5601:5601"
```

در این فایل، ما دو کانتینر تعریف کرده‌ایم:

* **elasticsearch:** این کانتینر Elasticsearch را اجرا می‌کند.
* **kibana:** این کانتینر Kibana را اجرا می‌کند.

3. **فایل `kibana.yml` را ایجاد کنید:**

```yaml
server.ssl: false
elasticsearch.hosts: http://localhost:9200
```

این فایل پیکربندی Kibana را برای اتصال به Elasticsearch در پورت 9200 تنظیم می‌کند.

4. **کانتینرها را با استفاده از Docker Compose راه‌اندازی کنید:**

```bash
docker-compose up -d
```

این دستور کانتینرهای Elasticsearch و Kibana را در پس‌زمینه راه‌اندازی می‌کند.

5. **صبر کنید تا کانتینرها راه‌اندازی شوند:**

```bash
docker-compose ps
```

خروجی این دستور باید چیزی شبیه به این باشد:

```
      CONTAINER STATUS         PORTS           NAMES
   -------------------------- -------------     ----------------------
   elasticsearch   up           9200/tcp, 9600/tcp   elasticsearch
     kibana        up           5601/tcp          kibana
```

6. **به Kibana دسترسی پیدا کنید:**

در مرورگر وب خود، به http://localhost:5601 بروید. این صفحه ورود Kibana را نشان می‌دهد. نام کاربری `elastic` و رمز عبور `password` را که در فایل `docker-compose.yml` تعریف کرده‌اید، وارد کنید.

7. **با Elasticsearch کار کنید:**

اکنون می‌توانید از Kibana برای ایجاد داشبورد، تجسم داده‌ها و کاوش در داده‌های خود با استفاده از Elasticsearch استفاده کنید.

### پیکربندی پیشرفته

شما می‌توانید فایل‌های `docker-compose.yml` و `kibana.yml` را برای پیکربندی بیشتر Elasticsearch و Kibana مطابق با نیازهای خود ویرایش کنید. برای اطلاعات بیشتر، به مستندات Elasticsearch و Kibana مراجعه کنید:

* [مستندات Elasticsearch](https://www.elastic.co/)
* [مستندات Kibana](https://www.elastic.co/guide/en/kibana/current/introduction.html)

### نتیجه

شما با موفقیت Elasticsearch و Kibana را با استفاده از Docker در یک محیط محلی راه‌اندازی کرده‌اید. اکنون می‌توانید از Kibana برای تجزیه و تحلیل و کاوش در داده‌های خود با استفاده از قدرت Elasticsearch استفاده کنید.
