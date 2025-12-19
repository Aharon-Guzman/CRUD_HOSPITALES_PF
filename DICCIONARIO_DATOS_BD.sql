select 
	a.name [tabla],
	b.name [columna], 
	c.name [tipo], 
	ISNULL(CASE
		WHEN c.name = 'numeric' OR  c.name = 'decimal' OR c.name = 'float'  THEN b.precision
		ELSE null
	END,'') [Precision], 
	b.max_length, 
	CASE 
		WHEN b.is_nullable = 0 THEN 'NO'
		ELSE 'SI'
	END [Permite Nulls],
	CASE 
		WHEN b.is_identity = 0 THEN 'NO'
		ELSE 'SI'
	END [Es Autonumerico],	
	ISNULL(ep.value,'!!!!!No hay descripción para el campo!!!!') [Descripcion],
    ISNULL(pk.name ,'')AS [PrimaryKeyName],
	ISNULL(f.ForeignKey,'') AS ForeignKey, 
	ISNULL(f.ReferenceTableName,'') AS ReferenceTableName,
	ISNULL(f.ReferenceColumnName,'') AS ReferenceColumnName

from sys.tables a   
	inner join sys.columns b on a.object_id= b.object_id 
	inner join sys.systypes c on b.system_type_id= c.xtype 
	inner join sys.objects d on a.object_id= d.object_id 
	LEFT JOIN sys.extended_properties ep ON d.object_id = ep.major_id AND b.column_Id = ep.minor_id
	LEFT JOIN (SELECT 
				f.name AS ForeignKey,
				OBJECT_NAME(f.parent_object_id) AS TableName,
				COL_NAME(fc.parent_object_id,fc.parent_column_id) AS ColumnName,
				OBJECT_NAME (f.referenced_object_id) AS ReferenceTableName,
				COL_NAME(fc.referenced_object_id,fc.referenced_column_id) AS ReferenceColumnName
				FROM sys.foreign_keys AS f
				INNER JOIN sys.foreign_key_columns AS fc ON f.OBJECT_ID = fc.constraint_object_id) 	f ON f.TableName =a.name AND f.ColumnName =b.name
	LEFT JOIN sys.indexes i ON i.object_id = a.object_id AND i.is_primary_key = 1
	LEFT JOIN sys.index_columns ic ON ic.object_id = a.object_id AND ic.index_id = i.index_id AND ic.column_id=b.column_id
	LEFT JOIN sys.key_constraints pk ON pk.parent_object_id = a.object_id AND pk.type = 'PK' AND ic.key_ordinal = 1
WHERE a.name <> 'sysdiagrams' and c.name <> 'sysname'
ORDER BY a.name,b.column_Id