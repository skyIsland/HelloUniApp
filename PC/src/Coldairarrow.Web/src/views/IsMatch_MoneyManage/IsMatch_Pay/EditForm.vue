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
        <a-form-model-item label="支出时间" prop="PayTime">
         <a-date-picker v-model="entity.PayTime" showTime format="YYYY-MM-DD HH:mm:ss" />   
        </a-form-model-item>
        <a-form-model-item label="支出方式" prop="PayWay">
         <a-select v-model="entity.PayWay">
          <a-select-option v-for="item in thisOptions" :key="item.value">{{ item.text }}</a-select-option>
          </a-select>
        </a-form-model-item>
        <a-form-model-item label="支付金额" prop="Money">
          <a-input v-model="entity.Money" autocomplete="off" />
        </a-form-model-item>
        <a-form-model-item label="支出类型" prop="PayType">
         <a-select v-model="entity.PayType">
          <a-select-option v-for="item in thisPayType" :key="item.value">{{ item.text }}</a-select-option>
          </a-select>                 
        </a-form-model-item>
         <a-form-model-item label="备注" prop="Remark">
          <a-textarea v-model="entity.Remark" :rows="4" />            
         </a-form-model-item>
      </a-form-model>
    </a-spin>
  </a-modal>
</template>

<script>
import moment from 'moment';
import 'moment/locale/zh-cn';
export default {
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
      title: '',
      thisOptions:[
        {text:'支付宝',value:1},
        {text:'微信',value:2}
      ],
      thisPayType:[
        {text:'吃',value:1},
        {text:'喝',value:2},
        {text:'玩',value:3},
        {text:'乐',value:4},
        {text:'住',value:5},
        {text:'理财',value:6}
      ],
       moment,
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
        this.$http.post('/IsMatch_MoneyManage/IsMatch_Pay/GetTheData', { id: id }).then(resJson => {
          this.loading = false
          this.entity = resJson.Data
        })
      }
    },
    handleSubmit() {
      this.$refs['form'].validate(valid => {
        if (!valid) {
          return
        }
        this.loading = true
        this.$http.post('/IsMatch_MoneyManage/IsMatch_Pay/SaveData', this.entity).then(resJson => {
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
