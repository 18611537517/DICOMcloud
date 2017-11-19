﻿using DICOMcloud.Pacs;
using DICOMcloud.DataAccess;
using DICOMcloud.DataAccess.Matching;
using System;
using System.Collections.Generic;
using fo = Dicom;


namespace DICOMcloud.Pacs
{
    public class ObjectArchieveQueryService : DicomQueryServiceBase, IObjectArchieveQueryService
    {
        public ObjectArchieveQueryService ( IObjectArchieveDataAccess dataAccess ) : base ( dataAccess )
        {}

        public IEnumerable<fo.DicomDataset> FindStudies 
        ( 
            fo.DicomDataset request, 
            IQueryOptions options
        )
        {
            return Find ( request, options, Enum.GetName (typeof(ObjectQueryLevel), ObjectQueryLevel.Study ) ) ;
        }

        public IEnumerable<fo.DicomDataset> FindObjectInstances
        (
            fo.DicomDataset request,
            IQueryOptions options
        )
        {
            return Find ( request, options, Enum.GetName (typeof(ObjectQueryLevel), ObjectQueryLevel.Instance ) ) ;
        }

        public IEnumerable<fo.DicomDataset> FindSeries
        (
            fo.DicomDataset request,
            IQueryOptions options
        )
        {
            return Find ( request, options, Enum.GetName (typeof(ObjectQueryLevel), ObjectQueryLevel.Series ) ) ;
        }

        protected override IEnumerable<fo.DicomDataset> DoFind
        (
           fo.DicomDataset request,
           IQueryOptions options,
           string queryLevel,
           IEnumerable<IMatchingCondition> conditions
        )
        {
            return QueryDataAccess.Search ( conditions, options, queryLevel ) ;
        }
    }
}
