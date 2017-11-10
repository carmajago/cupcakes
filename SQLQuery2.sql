SELECT YEAR(fecha) ano,MONTH(fecha) mes,SUM(valor) valor from Ingresoes group by  MONTH(fecha),YEAR(fecha)  


select * from Gastoes ,Ingresoes