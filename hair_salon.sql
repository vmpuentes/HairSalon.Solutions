""" database class object creation (initialization) """
if request.env.web2py_runtime_gae:                  # if running on Google App Engine
    dbOBJECT = DAL('gae')                           # connect to Google BigTable
    session.connect(request, response, db=dbOBJECT) # and store sessions and tickets there
else:                                               # else use a normal relational database
    dbOBJECT = DAL("sqlite://dbOBJECT.db")

dbOBJECT.define_table("stylist",
    Field("name", "string", default=None))

dbOBJECT.define_table("client",
    Field("name", "string", default=None),
    Field("desciption", "string", default=None),
    Field("stylist_id", "reference stylist"))

""" Relations between tables (remove fields you don't need from requires) """
dbOBJECT.client.stylist_id.requires=IS_IN_DB( dbOBJECT, 'stylist.id', ' %(name)s')
