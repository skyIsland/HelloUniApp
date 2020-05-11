<template>
  <a-modal
    :title="title"
    width="40%"
    :visible="visible"
    :confirmLoading="loading"
    @ok="handleSubmit"
    @cancel="()=>{this.visible=false}"
  >
    <a-spin :spinning="loading">
      <a-form-model ref="form" :model="entity" :rules="rules" v-bind="layout">
         <a-form-model-item label="时间" prop="Time">
         <a-date-picker v-model="entity.Time" showTime format="YYYY-MM-DD HH:mm:ss" />   
        </a-form-model-item>
        <a-form-model-item label="类型" prop="Type">
         <c-select
          v-model="entity.Type"
          url="/Base_Manage/IsMatch_DictionaryItems/GetOptionList?dictionaryCode=LiabilityType"
          searchMode="server"
        ></c-select>                                 
        </a-form-model-item>
        <a-form-model-item label="金额" prop="Money">
          <a-input v-model="entity.Money" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="备注" prop="Remark">
          <a-textarea v-model="entity.Remark" :rows="4" />            
         </a-form-model-item>
      </a-form-model>
    </a-spin>
  </a-modal>
</template>

<script>
import CSelect from '@/components/CSelect/CSelect'
import moment from 'moment';
import 'moment/locale/zh-cn';
export default {
   components:{
    CSelect
  },
  props: {
    parentObj: Object
  },
  data() {
    return {
      layout: {
        labelCol: { span: 5 },
        wrapperCol: { span: 18 }
      },
      visible: false,
      loading: false,
      entity: {},
      rules: {},
      title: ''     
    }
  },
  methods: {
    init() {
      this.visible = true
      this.entity = {}
      this.$nextTick(() => {
        this.$refs['form'].clearValidate()
      })
    },
    openForm(id, title) {
      this.init()

      if (id) {
        this.loading = true
        this.$http.post('/IsMatch_MoneyManage/IsMatch_Liabilities/GetTheData', { id: id }).then(resJson => {
          this.loading = false

          this.entity = resJson.Data
          this.entity.Time = moment(this.entity.Time)
        })
      }
    },
    handleSubmit() {
      this.$refs['form'].validate(valid => {
        if (!valid) {
          return
        }
        this.loading = true
        this.$http.post('/IsMatch_MoneyManage/IsMatch_Liabilities/SaveData', this.entity).then(resJson => {
          this.loading = false

          if (resJson.Success) {
            this.$message.success('操作成功!')
            this.visible = false

            this.parentObj.getDataList()
          } else {
            this.$message.error(resJson.Msg)
          }
        })
      })
    }
  }
}
</script>
